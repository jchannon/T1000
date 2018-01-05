namespace MediatRWebAPI.Features.Films.UpdateFilm
{
    using System;
    using MediatR;
    using MediatRWebAPI.Features.Films.ListFilmByIdQuery;
    using MediatRWebAPI.Features.Permissions;

    public class UpdateFilmMessageHandler : IRequestHandler<UpdateFilmMessage, Unit>
    {
        private readonly IListFilmByIdQuery listFilmByIdQuery;

        private readonly IValidUserQuery validUserQuery;

        public UpdateFilmMessageHandler(IListFilmByIdQuery listFilmByIdQuery, IValidUserQuery validUserQuery)
        {
            this.listFilmByIdQuery = listFilmByIdQuery;
            this.validUserQuery = validUserQuery;
        }

        public Unit Handle(UpdateFilmMessage message)
        {
            if (!this.validUserQuery.Execute())
            {
                throw new InvalidOperationException();
            }

            //Do some special MEGA CORP business validation

            var existingFilm = this.listFilmByIdQuery.Execute(message.Id);

            existingFilm.Name = message.Film.Name;
            existingFilm.Budget = message.Film.Budget;
            existingFilm.Language = message.Film.Language;
            
            //Write some SQL to store in db
            
            return new Unit();
        }
    }
}
