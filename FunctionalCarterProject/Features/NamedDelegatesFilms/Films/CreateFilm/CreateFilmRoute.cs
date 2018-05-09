namespace FunctionalCarterProject.Features.NamedDelegatesFilms.Films.CreateFilm
{
    using System;
    using Models;

    public static class CreateFilmRoute
    {
        public static void Handle(Film film, ValidUserDelegate validUserQuery)
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
