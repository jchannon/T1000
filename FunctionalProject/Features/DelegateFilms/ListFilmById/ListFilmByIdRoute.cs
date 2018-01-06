namespace FunctionalProject.Features.DelegateFilms.ListFilmById
{
    using System;
    using Models;

    public static class ListFilmByIdRoute
    {
        public static Film Handle(int id, Func<int,Film> listFilmById)
        {
            var film = listFilmById(id);

            return film;
        }
    }
}
