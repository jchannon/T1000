namespace TraditionalWebAPI.Services
{
    using System.Collections.Generic;
    using Models;

    public interface ICastMemberService
    {
        IEnumerable<CastMember> ListCastMembersByFilmId(int filmId);

        //Lots of other methods
    }
}
