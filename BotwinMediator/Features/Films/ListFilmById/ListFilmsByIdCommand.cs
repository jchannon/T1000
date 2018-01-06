namespace BotwinMediator.Features.Films.ListFilmById
{
    public class ListFilmsByIdCommand
    {
        public int Id { get; }

        public ListFilmsByIdCommand(int id)
        {
            this.Id = id;
        }
    }
}