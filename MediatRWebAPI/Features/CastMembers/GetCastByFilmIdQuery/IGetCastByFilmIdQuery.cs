namespace MediatRWebAPI.Features.CastMembers.GetCastByFilmIdQuery
{
    using System.Collections.Generic;
    using Models;

    public interface IGetCastByFilmIdQuery
    {
        IEnumerable<CastMember> Execute(int filmId);
    }
}
