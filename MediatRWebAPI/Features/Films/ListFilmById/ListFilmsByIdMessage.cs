namespace MediatRWebAPI.Features.Films.ListFilmById
{
    using MediatR;
    using Models;

    public class ListFilmsByIdMessage : IRequest<Film>
    {
        public int Id { get; }

        public ListFilmsByIdMessage(int id)
        {
            this.Id = id;
        }
    }
}