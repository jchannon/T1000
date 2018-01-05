namespace TraditionalWebAPI.Services
{
    using System.Collections.Generic;
    using Models;

    public interface IFilmService
    {
        IEnumerable<Film> ListFilms();

        Film ListFilmById(int id);
        
        void CreateFilm(Film film);

        void UpdateFilm(int id, Film film);

        void DeleteFilm(int id);
    }
}
