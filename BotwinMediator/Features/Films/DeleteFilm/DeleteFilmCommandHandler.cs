namespace BotwinMediator.Features.Films.DeleteFilm
{
    using System;
    using BotwinMediator.Features.Permissions;

    public class DeleteFilmCommandHandler : CommandHandler<DeleteFilmCommand>
    {
        private readonly IValidUserQuery validUserQuery;

        public DeleteFilmCommandHandler(IValidUserQuery validUserQuery)
        {
            this.validUserQuery = validUserQuery;
        }

        protected override void Handle(DeleteFilmCommand command)
        {
            if (!this.validUserQuery.Execute())
            {
                throw new InvalidOperationException();
            }

            //Write some SQL to delete from DB
        }
    }
}
