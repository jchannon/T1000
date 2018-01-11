namespace TradtionalWebAPI.Tests.Services
{
    using System;
    using FakeItEasy;
    using Models;
    using TraditionalWebAPI.Repositories;
    using TraditionalWebAPI.Services;
    using Xunit;

    public class FilmServiceTests
    {
        [Fact]
        public void Should_call_film_repo_to_get_films()
        {
            //Test fakes to see if they are called, integration test repositories

            //Given
            var fakeFilmRepository = A.Fake<IFilmRepository>();
            var fakeFilmService = this.GetFilmService(fakeFilmRepository);

            //When 
            fakeFilmService.ListFilms();

            //Then
            A.CallTo(() => fakeFilmRepository.ListFilms()).MustHaveHappened();
        }

        [Fact]
        public void Should_call_film_repo_to_get_film_by_id()
        {
            //Test fakes to see if they are called, integration test repositories

            //Given
            var fakeFilmRepository = A.Fake<IFilmRepository>();
            var fakeFilmService = this.GetFilmService(fakeFilmRepository);

            //When 
            fakeFilmService.ListFilmById(1);

            //Then
            A.CallTo(() => fakeFilmRepository.ListFilmById(1)).MustHaveHappened();
        }

        [Fact]
        public void Should_call_film_repo_to_save_new_film()
        {
            //Test fakes to see if they are called, integration test repositories

            //Given
            var fakeFilmRepository = A.Fake<IFilmRepository>();
            var fakeFilmService = this.GetFilmService(fakeFilmRepository);

            //When 
            fakeFilmService.CreateFilm(new Film());

            //Then
            A.CallTo(() => fakeFilmRepository.CreateFilm(A<Film>.Ignored)).MustHaveHappened();
        }

        [Fact]
        public void Should_throw_exception_when_creating_film_with_invalid_user()
        {
            //Given
            var fakePermissionService = A.Fake<IPermissionService>();
            A.CallTo(() => fakePermissionService.ValidUser()).Returns(false);
            var filmService = this.GetFilmService(permissionService: fakePermissionService);

            //When & Then
            Assert.Throws<InvalidOperationException>(() => filmService.CreateFilm(new Film()));
        }

        [Fact]
        public void Should_throw_exception_when_updating_film_with_invalid_user()
        {
            //Given
            var fakePermissionService = A.Fake<IPermissionService>();
            A.CallTo(() => fakePermissionService.ValidUser()).Returns(false);
            var filmService = this.GetFilmService(permissionService: fakePermissionService);

            //When & Then
            Assert.Throws<InvalidOperationException>(() => filmService.UpdateFilm(1, new Film()));
        }

        [Fact]
        public void Should_call_film_repo_to_update_film()
        {
            //Test fakes to see if they are called, integration test repositories

            //Given
            var fakeFilmRepository = A.Fake<IFilmRepository>();
            var fakeFilmService = this.GetFilmService(fakeFilmRepository);

            //When 
            fakeFilmService.UpdateFilm(1, new Film());

            //Then
            A.CallTo(() => fakeFilmRepository.UpdateFilm(A<Film>.Ignored)).MustHaveHappened();
        }

        [Fact]
        public void Should_throw_exception_when_deleting_film_with_invalid_user()
        {
            //Given
            var fakePermissionService = A.Fake<IPermissionService>();
            A.CallTo(() => fakePermissionService.ValidUser()).Returns(false);
            var filmService = this.GetFilmService(permissionService: fakePermissionService);

            //When & Then
            Assert.Throws<InvalidOperationException>(() => filmService.DeleteFilm(1));
        }

        [Fact]
        public void Should_call_film_repo_to_delete_film()
        {
            //Test fakes to see if they are called, integration test repositories

            //Given
            var fakeFilmRepository = A.Fake<IFilmRepository>();
            var fakeFilmService = this.GetFilmService(fakeFilmRepository);

            //When 
            fakeFilmService.DeleteFilm(1);

            //Then
            A.CallTo(() => fakeFilmRepository.DeleteFilm(1)).MustHaveHappened();
        }

        private FilmService GetFilmService(IFilmRepository filmRepository = null, IPermissionService permissionService = null)
        {
            var fakeFilmRepository = filmRepository ?? A.Fake<IFilmRepository>();
            var fakeDirectorService = A.Fake<IDirectorService>();
            var fakeCastMemberService = A.Fake<ICastMemberService>();

            if (permissionService == null)
            {
                permissionService = A.Fake<IPermissionService>();
                A.CallTo(() => permissionService.ValidUser()).Returns(true);
            }

            return new FilmService(fakeFilmRepository, fakeDirectorService, fakeCastMemberService, permissionService);
        }
    }
}
