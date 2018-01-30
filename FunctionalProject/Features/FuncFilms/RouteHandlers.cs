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
        public static Func<IEnumerable<Film>> ListFilmsHandler;

        public static Func<int, Film> ListFilmByIdHandler;

        public static Action<int, Film> UpdateFilmHandler;

        public static Action<Film> CreateFilmHandler;

        public static Action<int> DeleteFilmHandler;

        //private static Func<int,Film> getFilmyById = i => new Film { Id = 1, Name = "Pulp Fiction", DirectorId = 1 };

        static RouteHandlers()
        {
            ListFilmsHandler = () => ListFilmsRoute.Handle();

            ListFilmByIdHandler = filmId => ListFilmByIdRoute.Handle(filmId,
                //Write some SQL to get the film
                fId => new Film { Id = 1, Name = "Pulp Fiction", DirectorId = 1 },
                //Write some SQL to get the director
                dirId => new Director { Name = "Steven Spielberg" },
                //Write some SQL to get the cast
                fId => new[] { new CastMember { Name = "John Travolta" }, new CastMember { Name = "Samuel L Jackson" } }
            );

            UpdateFilmHandler = (filmId, film) => UpdateFilmRoute.Handle(
                filmId,
                film,
                () => new Random().Next() % 2 == 0,
                fId => new Film { Id = 1, Name = "Pulp Fiction", DirectorId = 1 }
            );
            
            CreateFilmHandler = film => CreateFilmRoute.Handle(film, () => new Random().Next() % 2 == 0);

            DeleteFilmHandler = id => DeleteFilmRoute.Handle(id, () => new Random().Next() % 2 == 0);
        }
    }
}
