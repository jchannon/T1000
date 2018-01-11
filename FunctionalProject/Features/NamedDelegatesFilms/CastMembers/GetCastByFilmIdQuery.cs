namespace FunctionalProject.Features.NamedDelegatesFilms.CastMembers
{
    using System.Collections.Generic;
    using Models;

    public static class GetCastByFilmIdQuery
    {
        public static IEnumerable<CastMember> Execute(int filmId)
        {
            //Do some SQL

            return new[] { new CastMember { Name = "John Travolta" }, new CastMember { Name = "Samuel L Jackson" } };
        }
    }
}
