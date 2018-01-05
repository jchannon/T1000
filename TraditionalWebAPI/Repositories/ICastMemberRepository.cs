namespace TraditionalWebAPI.Repositories
{
    using System.Collections.Generic;
    using Models;

    public interface ICastMemberRepository
    {
        IEnumerable<CastMember> ListAllCastMembers();

        IEnumerable<CastMember> ListCastMembersByFilmId(int filmId);

        //Lots of other methods
    }
}