namespace BotwinMediator.Features.Films.UpdateFilm
{
    using Models;

    public class UpdateFilmCommand
    {
        public int Id { get; }

        public Film Film { get; }

        public UpdateFilmCommand(int id, Film film)
        {
            this.Id = id;
            this.Film = film;
        }    
    }
}
