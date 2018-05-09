namespace HandRolledMediator.Features.Films.CreateFilm
{
    using System;
    using HandRolledMediator.Features.Permissions;

    public class CreateFilmCommandHandler : CommandHandler<CreateFilmCommand>
    {
        private readonly IValidUserQuery validUserQuery;

        public CreateFilmCommandHandler(IValidUserQuery validUserQuery)
        {
            this.validUserQuery = validUserQuery;
        }

        protected override void Handle(CreateFilmCommand command)
        {
            if (!this.validUserQuery.Execute())
            {
                throw new InvalidOperationException();
            }

            //Do some special MEGA CORP business validation

            //Save to database by writing SQL here

        }
    }
}
