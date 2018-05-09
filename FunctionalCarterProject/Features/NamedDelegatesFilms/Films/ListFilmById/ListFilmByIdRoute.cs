namespace FunctionalCarterProject.Features.NamedDelegatesFilms.Films.ListFilmById
{
    using Models;

    public static class ListFilmByIdRoute
    {
        public static Film Handle(int id, ListFilmByIdDelegate listFilmById, GetDirectorByIdDelegate getDirectorByIdDelegate, GetCastByFilmIdDelegate getCastByFilmIdDelegateQuery)
        {
            var film = listFilmById(id);

            if (film == null)
            {
                return null;
            }

            var director = getDirectorByIdDelegate(film.DirectorId);
            film.Director = director;

            var cast = getCastByFilmIdDelegateQuery(id);
            film.Cast = cast;

            return film;
        }
    }
}
