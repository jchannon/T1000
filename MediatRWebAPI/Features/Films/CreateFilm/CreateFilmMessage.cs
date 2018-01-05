namespace MediatRWebAPI.Features.Films.CreateFilm
{
    using MediatR;
    using Models;

    public class CreateFilmMessage : IRequest
    {
        public Film Film { get; }

        public CreateFilmMessage(Film film)
        {
            this.Film = film;
        }
    }
}
