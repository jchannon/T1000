namespace HandRolledMediator.Features.Films.ListFilms
{
    using Models;

    public class ListFilmsCommandHandler : CommandHandler<ListFilmsCommand>
    {
        protected override object Execute(ListFilmsCommand command)
        {
            return new[] { new Film { Id = 1, Name = "Pulp Fiction" }, new Film { Id = 2, Name = "Trainspotting" } };
        }
    }
}
