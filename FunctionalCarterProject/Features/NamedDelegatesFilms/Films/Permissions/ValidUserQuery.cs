namespace FunctionalCarterProject.Features.NamedDelegatesFilms.Films.Permissions
{
    using System;

    public static class ValidUserQuery
    {
        public static bool Execute()
        {
            return new Random().Next() % 2 == 0;
        }
    }
}
