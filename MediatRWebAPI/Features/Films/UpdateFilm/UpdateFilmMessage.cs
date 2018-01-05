namespace MediatRWebAPI.Features.Films.UpdateFilm
{
    using MediatR;
    using Models;

    public class UpdateFilmMessage : IRequest
    {
        public int Id { get; }

        public Film Film { get; }

        public UpdateFilmMessage(int id, Film film)
        {
            this.Id = id;
            this.Film = film;
        }    
    }
}
