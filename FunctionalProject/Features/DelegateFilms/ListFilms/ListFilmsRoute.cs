namespace FunctionalProject.Features.DelegateFilms.ListFilms
{
    using System.Collections.Generic;
    using Models;

    public static class ListFilmsRoute
    {
        public static IEnumerable<Film> Handle()
        {
            return new[] { new Film { Id = 1, Name = "Pulp Fiction" }, new Film { Id = 2, Name = "Trainspotting" } };
        }
    }
}
