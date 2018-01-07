namespace TraditionalWebAPI.Services
{
    using System.Collections.Generic;
    using Models;
    using TraditionalWebAPI.Repositories;

    public class CastMemberService : ICastMemberService
    {
        private readonly ICastMemberRepository castMemberRepository;

        public CastMemberService(ICastMemberRepository castMemberRepository)
        {
            this.castMemberRepository = castMemberRepository;
        }

        public IEnumerable<CastMember> ListCastMembersByFilmId(int filmId)
        {
            return this.castMemberRepository.ListCastMembersByFilmId(filmId);
        }
    }
}
