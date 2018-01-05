namespace Models
{
    using FluentValidation;

    public class FilmValidator : AbstractValidator<Film>
    {
        public FilmValidator()
        {
            this.RuleFor(x => x.Name).NotEmpty();
        }
    }
}
