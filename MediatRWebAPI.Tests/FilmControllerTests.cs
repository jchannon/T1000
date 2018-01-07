namespace MediatRWebAPI.Tests
{
    using System;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using FakeItEasy;
    using FluentValidation;
    using FluentValidation.AspNetCore;
    using MediatR;
    using MediatRWebAPI.Features.Films.CreateFilm;
    using MediatRWebAPI.Features.Films.DeleteFilm;
    using MediatRWebAPI.Features.Films.ListFilmById;
    using MediatRWebAPI.Features.Films.ListFilms;
    using MediatRWebAPI.Features.Films.UpdateFilm;
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.TestHost;
    using Microsoft.Extensions.DependencyInjection;
    using Models;
    using Newtonsoft.Json;
    using Xunit;

    public class FilmControllerTests
    {
        [Fact]
        public async Task Should_get_list_of_films()
        {
            //Given
            var fakeMediatR = A.Fake<IMediator>();
            A.CallTo(() => fakeMediatR.Send(A<ListFilmsMessage>.Ignored)).Returns(new[] { new Film { Name = "Goodfellas" } });
            var client = this.GetClient(fakeMediatR);

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
            var fakeMediatR = A.Fake<IMediator>();
            A.CallTo(() => fakeMediatR.Send(A<ListFilmsByIdMessage>.Ignored)).Returns(new Film { Name = "Blade Runner" });
            var client = this.GetClient(fakeMediatR);

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
            var fakeMediatR = A.Fake<IMediator>();
            A.CallTo(() => fakeMediatR.Send(A<ListFilmsByIdMessage>.Ignored)).Returns(null);

            var client = this.GetClient(fakeMediatR);

            //When
            var response = await client.GetAsync("/api/films/1");

            //Then
            Assert.Equal(404, (int)response.StatusCode);
        }

        [Fact]
        public async Task Should_return_400_on_invalid_data_when_creating_film()
        {
            //Given
            var fakeMediatR = A.Fake<IMediator>();
            var client = this.GetClient(fakeMediatR);
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
            var fakeMediatR = A.Fake<IMediator>();
            A.CallTo(() => fakeMediatR.Send(A<CreateFilmMessage>.Ignored)).Throws<InvalidOperationException>();

            var client = this.GetClient(fakeMediatR);

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
            var fakeMediatR = A.Fake<IMediator>();
            A.CallTo(() => fakeMediatR.Send(A<CreateFilmMessage>.Ignored)).Returns(new Unit());
            var client = this.GetClient(fakeMediatR);

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
            var fakeMediatR = A.Fake<IMediator>();
            var client = this.GetClient(fakeMediatR);
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
            var fakeMediatR = A.Fake<IMediator>();
            A.CallTo(() => fakeMediatR.Send(A<UpdateFilmMessage>.Ignored)).Throws<InvalidOperationException>();

            var client = this.GetClient(fakeMediatR);

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
            var fakeMediatR = A.Fake<IMediator>();
            A.CallTo(() => fakeMediatR.Send(A<UpdateFilmMessage>.Ignored)).Returns(new Unit());
            var client = this.GetClient(fakeMediatR);

            //When
            var response = await client.DeleteAsync("/api/films/1");

            //Then
            Assert.Equal(204, (int)response.StatusCode);
        }

        [Fact]
        public async Task Should_return_403_on_invalid_user_when_deleting_film()
        {
            //Given
            var fakeMediatR = A.Fake<IMediator>();
            A.CallTo(() => fakeMediatR.Send(A<DeleteFilmMessage>.Ignored)).Throws<InvalidOperationException>();

            var client = this.GetClient(fakeMediatR);

            //When
            var response = await client.DeleteAsync("/api/films/1");

            //Then
            Assert.Equal(403, (int)response.StatusCode);
        }

        [Fact]
        public async Task Should_return_204_when_updating_film()
        {
            //Given
            var fakeMediatR = A.Fake<IMediator>();
            A.CallTo(() => fakeMediatR.Send(A<DeleteFilmMessage>.Ignored)).Returns(new Unit());
            var client = this.GetClient(fakeMediatR);
            
            var film = new Film { Name = "Shrek" };

            //When
            var response = await client.PutAsync("/api/films/1", new StringContent(JsonConvert.SerializeObject(film), Encoding.UTF8, "application/json"));

            //Then
            Assert.Equal(204, (int)response.StatusCode);
        }
        
        private HttpClient GetClient(IMediator fakeMediatR)
        {
            var server = new TestServer(WebHost.CreateDefaultBuilder()
                .Configure(app => { app.UseMvc(); })
                .ConfigureServices(services =>
                {
                    services.AddSingleton<IMediator>(fakeMediatR);

                    services.AddTransient<IValidator<Film>, FilmValidator>();

                    services.AddMvc().AddFluentValidation();
                })
            );

            return server.CreateClient();
        }
    }
}
