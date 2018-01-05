namespace MediatRWebAPI.Features.Films.ListFilms
{
    using System.Collections.Generic;
    using MediatR;
    using Models;

    public class ListFilmsMessage : IRequest<IEnumerable<Film>>
    {
        
    }
}
