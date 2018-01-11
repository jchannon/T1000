namespace FunctionalProject.Features.FuncFilms.CreateFilm
{
    using System;
    using Models;

    public static class CreateFilmRoute
    {
        public static void Handle(Film film, Func<bool> validUserQuery)
        {
            if (!validUserQuery())
            {
                throw new InvalidOperationException();
            }

            //Do some special MEGA CORP business validation

            //Save to database by writing SQL here
        }
    }
}
