namespace TraditionalWebAPI.Repositories
{
    using System.Collections.Generic;
    using Models;

    public class CastMemberRepository : ICastMemberRepository
    {
        public IEnumerable<CastMember> ListAllCastMembers()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<CastMember> ListCastMembersByFilmId(int filmId)
        {
            return new[] { new CastMember { Name = "John Travolta" }, new CastMember { Name = "Samuel L Jackson" } };
        }
    }
}