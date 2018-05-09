namespace HandRolledMediator.Features.Films.CreateFilm
{
    using Models;

    public class CreateFilmCommand
    {
        public Film Film { get; }

        public CreateFilmCommand(Film film)
        {
            this.Film = film;
        }
    }
}
