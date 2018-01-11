namespace FunctionalProjectTests.Features.Films
{
    using System;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using Botwin;
    using FunctionalProject.Features.NamedDelegatesFilms.Films;
    using FunctionalProject.Features.NamedDelegatesFilms.Films.CreateFilm;
    using FunctionalProject.Features.NamedDelegatesFilms.Films.ListFilmById;
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.TestHost;
    using Models;
    using Newtonsoft.Json;
    using Xunit;

    public class FilmTests
    {
        private TestServer server;

        private HttpClient client;

        public FilmTests()
        {
            server = new TestServer(WebHost.CreateDefaultBuilder()
                .ConfigureServices(services => services.AddBotwin(typeof(RouteHandlers).Assembly, typeof(FilmValidator).Assembly))
                .Configure(app => app.UseBotwin())
            );

            client = server.CreateClient();
        }

        [Fact]
        public async Task Should_return_422_on_invalid_data_when_creating_film()
        {
            //Given

            //No mock library required to fake the UserValidQuery we just invoke a func to return true/false

            RouteHandlers.CreateFilmHandler = film => CreateFilmRoute.Handle(film, () => true);

            var newFilm = new Film { Name = "" };

            //When
            var response = await client.PostAsync("/api/delegate/films", new StringContent(JsonConvert.SerializeObject(newFilm), Encoding.UTF8, "application/json"));

            //Then
            Assert.Equal(422, (int)response.StatusCode);
        }

        [Fact]
        public async Task Should_return_403_on_invalid_user_when_creating_film()
        {
            //Given
            RouteHandlers.CreateFilmHandler = film => CreateFilmRoute.Handle(film, () => false);

            var newFilm = new Film { Name = "Shrek" };

            //When
            var response = await client.PostAsync("/api/delegate/films", new StringContent(JsonConvert.SerializeObject(newFilm), Encoding.UTF8, "application/json"));

            //Then
            Assert.Equal(403, (int)response.StatusCode);
        }

        [Fact]
        public async Task Should_return_201_when_creating_film()
        {
            //Given
            RouteHandlers.CreateFilmHandler = film => CreateFilmRoute.Handle(film, () => true);

            var newFilm = new Film { Name = "Shrek" };

            //When
            var response = await client.PostAsync("/api/delegate/films", new StringContent(JsonConvert.SerializeObject(newFilm), Encoding.UTF8, "application/json"));

            //Then
            Assert.Equal(201, (int)response.StatusCode);
        }

        [Fact]
        public async Task Should_get_film_by_id()
        {
            //Given

            //No mock library required to fake the GetFilmBtIdDelegate, GetDirectorById, GetCastMembersByFilmId we just invoke a func

            RouteHandlers.ListFilmByIdHandler = id => ListFilmByIdRoute.Handle(id, filmid => new Film { Name = "Blade Runner" }, i => new Director(), filmId => new[] { new CastMember() });

            //When
            var response = await client.GetAsync("/api/delegate/films/1");
            var contents = await response.Content.ReadAsStringAsync();

            //Then
            Assert.Contains("Blade Runner", contents, StringComparison.OrdinalIgnoreCase);
        }

        [Fact]
        public async Task Should_return_404_when_no_film_found_via_get_film_by_id()
        {
            //Given

            //No mock library required to fake the GetFilmBtIdDelegate, GetDirectorById, GetCastMembersByFilmId we just invoke a func

            RouteHandlers.ListFilmByIdHandler = id => ListFilmByIdRoute.Handle(id, filmid => null, i => new Director(), filmId => new[] { new CastMember() });

            //When
            var response = await client.GetAsync("/api/delegate/films/1");

            //Then
            Assert.Equal(404, (int)response.StatusCode);
        }
    }
}
