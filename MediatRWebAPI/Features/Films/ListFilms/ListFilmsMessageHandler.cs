namespace MediatRWebAPI.Features.Films.ListFilms
{
    using System.Collections.Generic;
    using MediatR;
    using Models;

    public class ListFilmsMessageHandler : IRequestHandler<ListFilmsMessage, IEnumerable<Film>>
    {
        public IEnumerable<Film> Handle(ListFilmsMessage message)
        {
            return new[] { new Film { Id = 1, Name = "Pulp Fiction" }, new Film { Id = 2, Name = "Trainspotting" } };
        }
    }
}
