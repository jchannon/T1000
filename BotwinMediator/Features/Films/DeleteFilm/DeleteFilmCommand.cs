namespace BotwinMediator.Features.Films.DeleteFilm
{
    public class DeleteFilmCommand 
    {
        public int Id { get; }

        public DeleteFilmCommand(int id)
        {
            this.Id = id;
        }
    }
}
