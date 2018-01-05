namespace MediatRWebAPI.Features.Films.DeleteFilm
{
    using System;
    using MediatR;
    using MediatRWebAPI.Features.Permissions;

    public class DeleteFilmMessageHandler : IRequestHandler<DeleteFilmMessage, Unit>
    {
        private readonly IValidUserQuery validUserQuery;

        public DeleteFilmMessageHandler(IValidUserQuery validUserQuery)
        {
            this.validUserQuery = validUserQuery;
        }
        
        public Unit Handle(DeleteFilmMessage message)
        {
            if (!this.validUserQuery.Execute())
            {
                throw new InvalidOperationException();
            }
            
            //Write some SQL to delete from DB
            
            return new Unit();
        }
    }
}
