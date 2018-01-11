namespace TradtionalWebAPI.Tests.Controllers
{
    using System;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using FakeItEasy;
    using FluentValidation;
    using FluentValidation.AspNetCore;
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.TestHost;
    using Microsoft.Extensions.DependencyInjection;
    using Models;
    using Newtonsoft.Json;
    using TraditionalWebAPI.Services;
    using Xunit;

    public class FilmControllerTests
    {

        [Fact]
        public async Task Should_get_list_of_films()
        {
            //Given
            var client = this.GetClient();
            
            //When
            var response = await client.GetAsync("/api/films");
            var contents = await response.Content.ReadAsStringAsync();

            //Then
            Assert.Contains("Goodfellas", contents, StringComparison.OrdinalIgnoreCase);
        }

        [Fact]
        public async Task Should_get_film_by_id()
        {
            //Given
            var client = this.GetClient();
            
            //When
            var response = await client.GetAsync("/api/films/1");
            var contents = await response.Content.ReadAsStringAsync();

            //Then
            Assert.Contains("Blade Runner", contents, StringComparison.OrdinalIgnoreCase);
        }
        
        [Fact]
        public async Task Should_return_404_when_no_film_found_via_get_film_by_id()
        {
            //Given
            var fakeFilmService = A.Fake<IFilmService>();
            A.CallTo(() => fakeFilmService.ListFilmById(1)).Returns(null);
            
            var client = this.GetClient(fakeFilmService);
            
            //When
            var response = await client.GetAsync("/api/films/1");

            //Then
            Assert.Equal(404, (int)response.StatusCode);
        }

        [Fact]
        public async Task Should_return_400_on_invalid_data_when_creating_film()
        {
            //Given
            var client = this.GetClient();
            var film = new Film { Name = "" };

            //When
            var response = await client.PostAsync("/api/films", new StringContent(JsonConvert.SerializeObject(film), Encoding.UTF8, "application/json"));

            //Then
            Assert.Equal(400, (int)response.StatusCode);
        }
        
        [Fact]
        public async Task Should_return_403_on_invalid_user_when_creating_film()
        {
            //Given
            var fakeFilmService = A.Fake<IFilmService>();
            A.CallTo(() => fakeFilmService.CreateFilm(A<Film>.Ignored)).Throws<InvalidOperationException>();
            
            var client = this.GetClient(fakeFilmService);
            
            var film = new Film { Name = "Shrek" };

            //When
            var response = await client.PostAsync("/api/films", new StringContent(JsonConvert.SerializeObject(film), Encoding.UTF8, "application/json"));

            //Then
            Assert.Equal(403, (int)response.StatusCode);
        }
        
        [Fact]
        public async Task Should_return_201_when_creating_film()
        {
            //Given
            var client = this.GetClient();
            var film = new Film { Name = "Shrek" };

            //When
            var response = await client.PostAsync("/api/films", new StringContent(JsonConvert.SerializeObject(film), Encoding.UTF8, "application/json"));

            //Then
            Assert.Equal(201, (int)response.StatusCode);
        }
        
        [Fact]
        public async Task Should_return_400_on_invalid_data_when_updating_film()
        {
            //Given
            var client = this.GetClient();
            var film = new Film { Name = "" };

            //When
            var response = await client.PutAsync("/api/films/1", new StringContent(JsonConvert.SerializeObject(film), Encoding.UTF8, "application/json"));

            //Then
            Assert.Equal(400, (int)response.StatusCode);
        }
        
        [Fact]
        public async Task Should_return_403_on_invalid_user_when_updating_film()
        {
            //Given
            var fakeFilmService = A.Fake<IFilmService>();
            A.CallTo(() => fakeFilmService.UpdateFilm(1, A<Film>.Ignored)).Throws<InvalidOperationException>();
            
            var client = this.GetClient(fakeFilmService);
            
            var film = new Film { Name = "Shrek" };

            //When
            var response = await client.PutAsync("/api/films/1", new StringContent(JsonConvert.SerializeObject(film), Encoding.UTF8, "application/json"));

            //Then
            Assert.Equal(403, (int)response.StatusCode);
        }
        
        [Fact]
        public async Task Should_return_204_when_deleting_film()
        {
            //Given
            var client = this.GetClient();

            //When
            var response = await client.DeleteAsync("/api/films/1");

            //Then
            Assert.Equal(204, (int)response.StatusCode);
        }
        
        [Fact]
        public async Task Should_return_403_on_invalid_user_when_deleting_film()
        {
            //Given
            var fakeFilmService = A.Fake<IFilmService>();
            A.CallTo(() => fakeFilmService.DeleteFilm(1)).Throws<InvalidOperationException>();
            
            var client = this.GetClient(fakeFilmService);
            
            //When
            var response = await client.DeleteAsync("/api/films/1");

            //Then
            Assert.Equal(403, (int)response.StatusCode);
        }
        
        [Fact]
        public async Task Should_return_204_when_updating_film()
        {
            //Given
            var client = this.GetClient();
            var film = new Film { Name = "Shrek" };

            //When
            var response = await client.PutAsync("/api/films/1", new StringContent(JsonConvert.SerializeObject(film), Encoding.UTF8, "application/json"));

            //Then
            Assert.Equal(204, (int)response.StatusCode);
        }

        private HttpClient GetClient(IFilmService filmService = null)
        {
            if (filmService == null)
            {
                filmService = A.Fake<IFilmService>();
                A.CallTo(() => filmService.ListFilms()).Returns(new[] { new Film { Name = "Goodfellas" } });
                A.CallTo(() => filmService.ListFilmById(1)).Returns(new Film { Name = "Blade Runner" });
            }
            
            var server = new TestServer(WebHost.CreateDefaultBuilder()
                .Configure(app => { app.UseMvc(); })
                .ConfigureServices(services =>
                {
                    services.AddSingleton<IFilmService>(filmService);

                    services.AddTransient<IValidator<Film>, FilmValidator>();

                    services.AddMvc().AddFluentValidation();
                })
            );

            return server.CreateClient();
        }
    }
}
