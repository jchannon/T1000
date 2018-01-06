namespace BotwinMediator.Features.Films.UpdateFilm
{
    using System;
    using BotwinMediator.Features.Films.ListFilmByIdQuery;
    using BotwinMediator.Features.Permissions;

    public class UpdateFilmCommandHandler : CommandHandler<UpdateFilmCommand>
    {
        private readonly IListFilmByIdQuery listFilmByIdQuery;

        private readonly IValidUserQuery validUserQuery;

        public UpdateFilmCommandHandler(IListFilmByIdQuery listFilmByIdQuery, IValidUserQuery validUserQuery)
        {
            this.listFilmByIdQuery = listFilmByIdQuery;
            this.validUserQuery = validUserQuery;
        }

        protected override void Handle(UpdateFilmCommand command)
        {
            if (!this.validUserQuery.Execute())
            {
                throw new InvalidOperationException();
            }

            //Do some special MEGA CORP business validation

            var existingFilm = this.listFilmByIdQuery.Execute(command.Id);

            existingFilm.Name = command.Film.Name;
            existingFilm.Budget = command.Film.Budget;
            existingFilm.Language = command.Film.Language;
            
            //Write some SQL to store in db
            
        }
    }
}
