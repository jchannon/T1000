namespace FunctionalProject.Features.CompositionalDelegates
{
    using System;
    using System.Threading.Tasks;
    using Botwin;
    using Botwin.ModelBinding;
    using Botwin.Response;
    using FunctionalProject.Features.NamedDelegatesFilms.Films;
    using FunctionalProject.Features.NamedDelegatesFilms.Films.Permissions;
    using Microsoft.AspNetCore.Http;
    using Models;

    public class FilmsModule : BotwinModule
    {
        private readonly Films.CreateFilm createFilm;

        public FilmsModule() : base("/api/delegate-coposition/films")
        {
            // If the framework lets you, pass the wired-up functions into the constructor instead for testability
            this.createFilm = ApplicationServices.Default.createFilm;
            
            this.Post("/", this.CreateFilm);
        }

        private async Task CreateFilm(HttpContext context)
        {
            var result = context.Request.BindAndValidate<Film>();

            if (!result.ValidationResult.IsValid)
            {
                context.Response.StatusCode = 422;
                await context.Response.Negotiate(result.ValidationResult.GetFormattedErrors());
                return;
            }

            try
            {
                createFilm(result.Data);
                context.Response.StatusCode = 201;
            }
            catch (Exception)
            {
                context.Response.StatusCode = 403;
            }
        }
    }

    // This class composes all of the functions together with their dependencies. It is the composition root of the app
    // You would call this once when the application starts and then thread the functions into the controllers that need them
    public class ApplicationServices
    {
        public Films.CreateFilm createFilm;
        
        public ApplicationServices()
        {
            ValidUserDelegate vud = () => ValidUserQuery.Execute();

            // Use currying to supply 'constructor' dependencies
            createFilm = Films.Create(vud);
        }
        
        public static ApplicationServices Default => new ApplicationServices();
        
        // As this class grows large, you can chop it up into multiple cohesive classes e.g. FilmService
    }

    public static class Films
    {
        public delegate void CreateFilm(Film film);

        // This is effectively an object constructor
        public static CreateFilm Create(ValidUserDelegate validUserQuery)
        {
            // C# local method syntax makes it easy to return a function from a function
            // This function is basically the wired up object
            void func(Film film)
            {
                if (!validUserQuery())
                {
                    throw new InvalidOperationException();
                }

                //Do some special MEGA CORP business validation

                //Save to database by writing SQL here
            }

            return func;
        }
    }
}
