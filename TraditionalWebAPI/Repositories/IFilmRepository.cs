namespace TraditionalWebAPI.Repositories
{
    using System.Collections.Generic;
    using Models;

    public interface IFilmRepository
    {
        IEnumerable<Film> ListFilms();

        Film ListFilmById(int id);

        void CreateFilm(Film film);

        void UpdateFilm(Film existingFilm);

        void DeleteFilm(int id);
    }
}