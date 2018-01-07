namespace FunctionalProject.Features.DelegateFilms.UpdateFilm
{
    using System;
    using Models;

    public static class UpdateFilmRoute
    {
        public static void Handle(int id, Film film, Func<bool> validUserQuery, Func<int, Film> listFilmById)
        {
            if (!validUserQuery())
            {
                throw new InvalidOperationException();
            }

            //Do some special MEGA CORP business validation

            var existingFilm = listFilmById(id);

            existingFilm.Name = film.Name;
            existingFilm.Budget = film.Budget;
            existingFilm.Language = film.Language;
            
            //Write some SQL to store in db
            
        }
    }
}
