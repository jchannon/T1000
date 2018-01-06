namespace FunctionalProject.Features.DelegateFilms
{
    using System.Threading.Tasks;
    using Botwin;
    using Botwin.Request;
    using Botwin.Response;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Routing;

    public class FilmsModule : BotwinModule
    {
        public FilmsModule() : base("/api/films")
        {
            this.Get("/", this.GetFilms);
            this.Get("/{id:int}", this.GetFilmById);
        }

        private async Task GetFilms(HttpContext context)
        {
            var handler = RouteHandlers.ListFilmsHandler;

            var films = handler();

            await context.Response.AsJson(films);
        }

        private async Task GetFilmById(HttpContext context)
        {
            var handler = RouteHandlers.ListFilmBIdHandler;

            var film = handler(context.GetRouteData().As<int>("id"));

            if (film == null)
            {
                context.Response.StatusCode = 404;
                return;
            }

            await context.Response.AsJson(film);
        }
    }
}
