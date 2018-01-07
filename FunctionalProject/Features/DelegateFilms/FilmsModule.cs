namespace FunctionalProject.Features.DelegateFilms
{
    using System;
    using System.Threading.Tasks;
    using Botwin;
    using Botwin.ModelBinding;
    using Botwin.Request;
    using Botwin.Response;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Routing;
    using Models;

    public class FilmsModule : BotwinModule
    {
        public FilmsModule() : base("/api/films")
        {
            this.Get("/", this.GetFilms);
            this.Get("/{id:int}", this.GetFilmById);
            this.Put("/{id:int}", this.UpdateFilm);
        }

        private async Task UpdateFilm(HttpContext context)
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
                var handler = RouteHandlers.UpdateFilmHandler;

                handler(context.GetRouteData().As<int>("id"), result.Data);
                
                context.Response.StatusCode = 204;
            }
            catch (Exception)
            {
                context.Response.StatusCode = 403;
            }
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
