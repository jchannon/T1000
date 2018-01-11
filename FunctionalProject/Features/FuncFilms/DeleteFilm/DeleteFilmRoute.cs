namespace FunctionalProject.Features.FuncFilms.DeleteFilm
{
    using System;

    public static class DeleteFilmRoute
    {
        public static void Handle(int id, Func<bool> validUserQuery)
        {
            if (!validUserQuery())
            {
                throw new InvalidOperationException();
            }

            //Write some SQL to delete from DB
        }
    }
}
