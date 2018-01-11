namespace FunctionalProject.Features.FuncFilms
{
    using System;
    using System.Collections.Generic;
    using FunctionalProject.Features.FuncFilms.CreateFilm;
    using FunctionalProject.Features.FuncFilms.DeleteFilm;
    using FunctionalProject.Features.FuncFilms.ListFilmById;
    using FunctionalProject.Features.FuncFilms.ListFilms;
    using FunctionalProject.Features.FuncFilms.UpdateFilm;
    using Models;

    public static class RouteHandlers
    {
        private static Func<IEnumerable<Film>> listFilms;

        private static Func<int, Film> listFilmById;

        private static Action<int, Film> updateFilm;

        private static Action<Film> createFilm;

        private static Action<int> deleteFilm;

        //private static Func<int,Film> getFilmyById = i => new Film { Id = 1, Name = "Pulp Fiction", DirectorId = 1 };

        public static Func<IEnumerable<Film>> ListFilmsHandler
        {
            get => listFilms ?? ListFilmsRoute.Handle;
            set => listFilms = value;
        }

        public static Func<int, Film> ListFilmBIdHandler
        {
            get => listFilmById ?? (filmId => ListFilmByIdRoute.Handle(
                    filmId,
                    //Write some SQL to get the film
                    fId => new Film { Id = 1, Name = "Pulp Fiction", DirectorId = 1 },
                    //Write some SQL to get the director
                    dirId => new Director { Name = "Steven Spielberg" },
                    //Write some SQL to get the cast
                    fId => new[] { new CastMember { Name = "John Travolta" }, new CastMember { Name = "Samuel L Jackson" } }
                )
            );

            set => listFilmById = value;
        }

        public static Action<int, Film> UpdateFilmHandler
        {
            get => updateFilm ?? ((filmId, film) => UpdateFilmRoute.Handle(
                    filmId,
                    film,
                    () => new Random().Next() % 2 == 0,
                    fId => new Film { Id = 1, Name = "Pulp Fiction", DirectorId = 1 }
                )
            );

            set => updateFilm = value;
        }

        public static Action<Film> CreateFilmHandler
        {
            get => createFilm ?? (film => CreateFilmRoute.Handle(film, () => new Random().Next() % 2 == 0));
            set => createFilm = value;
        }

        public static Action<int> DeleteFilmHandler
        {
            get => deleteFilm ?? (id => DeleteFilmRoute.Handle(id, () => new Random().Next() % 2 == 0));
            set => deleteFilm = value;
        }
    }
}
