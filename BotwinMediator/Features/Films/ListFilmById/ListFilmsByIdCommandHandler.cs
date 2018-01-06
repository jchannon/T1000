namespace BotwinMediator.Features.Films.ListFilmById
{
    using BotwinMediator.Features.CastMembers.GetCastByFilmIdQuery;
    using BotwinMediator.Features.Directors.GetDirectorByIdQuery;
    using BotwinMediator.Features.Films.ListFilmByIdQuery;

    public class ListFilmsByIdCommandHandler : CommandHandler<ListFilmsByIdCommand>
    {
        private readonly IListFilmByIdQuery listFilmByIdQuery;

        private readonly IGetDirectorByIdQuery getDirectorByIdQuery;

        private readonly IGetCastByFilmIdQuery getCastByFilmIdQuery;

        public ListFilmsByIdCommandHandler(IListFilmByIdQuery listFilmByIdQuery, IGetDirectorByIdQuery getDirectorByIdQuery, IGetCastByFilmIdQuery getCastByFilmIdQuery)
        {
            this.listFilmByIdQuery = listFilmByIdQuery;
            this.getDirectorByIdQuery = getDirectorByIdQuery;
            this.getCastByFilmIdQuery = getCastByFilmIdQuery;

            //No need to inject IPermissionService as we don't need it
        }

        protected override object Execute(ListFilmsByIdCommand command)
        {
            //TODO Unit testing?

            //Use shared query to get film
            var film = this.listFilmByIdQuery.Execute(command.Id);

            var director = this.getDirectorByIdQuery.Execute(film.DirectorId);
            film.Director = director;

            var cast = this.getCastByFilmIdQuery.Execute(command.Id);
            film.Cast = cast;

            return film;
        }
    }
}
