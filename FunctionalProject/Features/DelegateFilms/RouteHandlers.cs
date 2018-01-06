namespace FunctionalProject.Features.DelegateFilms
{
    using System;
    using System.Collections.Generic;
    using FunctionalProject.Features.DelegateFilms.ListFilmById;
    using FunctionalProject.Features.DelegateFilms.ListFilms;
    using Models;

    public static class RouteHandlers
    {
        private static Func<IEnumerable<Film>> listFilms;

        private static Func<int, Film> listFilmById;

        public static Func<IEnumerable<Film>> ListFilmsHandler
        {
            get => listFilms ?? ListFilmsRoute.Handle;
            set => listFilms = value;
        }

        public static Func<int, Film> ListFilmBIdHandler
        {
            get => listFilmById ?? (filmId => ListFilmByIdRoute.Handle(filmId, fId => new Film
            {
                Id = 1,
                Name = "Pulp Fiction",
                DirectorId = 1
            }));

            set => listFilmById = value;
        }
    }
}
