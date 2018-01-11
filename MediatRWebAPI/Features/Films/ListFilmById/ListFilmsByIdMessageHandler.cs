namespace MediatRWebAPI.Features.Films.ListFilmById
{
    using MediatR;
    using MediatRWebAPI.Features.CastMembers.GetCastByFilmIdQuery;
    using MediatRWebAPI.Features.Directors.GetDirectorByIdQuery;
    using MediatRWebAPI.Features.Films.ListFilmByIdQuery;
    using Models;

    public class ListFilmsByIdMessageHandler : IRequestHandler<ListFilmsByIdMessage, Film>
    {
        private readonly IListFilmByIdQuery listFilmByIdQuery;

        private readonly IGetDirectorByIdQuery getDirectorByIdQuery;

        private readonly IGetCastByFilmIdQuery getCastByFilmIdQuery;

        public ListFilmsByIdMessageHandler(IListFilmByIdQuery listFilmByIdQuery, IGetDirectorByIdQuery getDirectorByIdQuery, IGetCastByFilmIdQuery getCastByFilmIdQuery)
        {
            this.listFilmByIdQuery = listFilmByIdQuery;
            this.getDirectorByIdQuery = getDirectorByIdQuery;
            this.getCastByFilmIdQuery = getCastByFilmIdQuery;
        
            //No need to inject IPermissionService as we don't need it
        }
        
        public Film Handle(ListFilmsByIdMessage message)
        {
            //Use shared query to get film
            var film = this.listFilmByIdQuery.Execute(message.Id);

            var director = this.getDirectorByIdQuery.Execute(film.DirectorId);
            film.Director = director;

            var cast = this.getCastByFilmIdQuery.Execute(message.Id);
            film.Cast = cast;

            return film;
        }
    }
}
