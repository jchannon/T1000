namespace BotwinMediator.Features.CastMembers.GetCastByFilmIdQuery
{
    using System.Collections.Generic;
    using Models;

    public class GetCastByFilmIdQuery : IGetCastByFilmIdQuery
    {
        public IEnumerable<CastMember> Execute(int filmId)
        {
            //Do some SQL
            
            return new[] { new CastMember { Name = "John Travolta" }, new CastMember { Name = "Samuel L Jackson" } };
        }
    }
}