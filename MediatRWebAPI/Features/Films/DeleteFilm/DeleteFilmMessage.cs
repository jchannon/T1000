namespace MediatRWebAPI.Features.Films.DeleteFilm
{
    using MediatR;

    public class DeleteFilmMessage : IRequest
    {
        public int Id { get; }

        public DeleteFilmMessage(int id)
        {
            this.Id = id;
        }
    }
}
