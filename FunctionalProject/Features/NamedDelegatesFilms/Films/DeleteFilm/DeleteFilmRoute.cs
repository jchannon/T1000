namespace FunctionalProject.Features.NamedDelegatesFilms.Films.DeleteFilm
{
    using System;

    public static class DeleteFilmRoute
    {
        public static void Handle(int id, ValidUserDelegate validUserQuery)
        {
            if (!validUserQuery())
            {
                throw new InvalidOperationException();
            }

            //Write some SQL to delete from DB
        }
    }
}
