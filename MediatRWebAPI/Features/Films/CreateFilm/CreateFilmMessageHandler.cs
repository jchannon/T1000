namespace MediatRWebAPI.Features.Films.CreateFilm
{
    using System;
    using MediatR;
    using MediatRWebAPI.Features.Permissions;

    public class CreateFilmMessageHandler : IRequestHandler<CreateFilmMessage,Unit>
    {
        private readonly IValidUserQuery validUserQuery;

        public CreateFilmMessageHandler(IValidUserQuery validUserQuery)
        {
            this.validUserQuery = validUserQuery;
        }
        public Unit Handle(CreateFilmMessage message)
        {
            if (!this.validUserQuery.Execute())
            {
                throw new InvalidOperationException();
            }
            
            //Do some special MEGA CORP business validation
            
            //Save to database by writing SQL here
            
            return new Unit();
        }
    }
}
