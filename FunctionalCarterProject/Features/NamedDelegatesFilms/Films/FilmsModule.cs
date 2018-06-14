namespace FunctionalCarterProject.Features.NamedDelegatesFilms.Films
{
    using System;
    using System.Threading.Tasks;
    using Carter;
    using Carter.ModelBinding;
    using Carter.Request;
    using Carter.Response;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Routing;
    using Models;
    
    /*** NO ATTRIBUTES ANYWHERE!!! ***/

    public class FilmsModule : CarterModule
    {
        public FilmsModule() : base("/api/delegate/films") // --> REPLACE ATTRIBUTES WITH METHOD CALLS ***/
        {
            /*** REPLACE ATTRIBUTES WITH METHOD CALLS ***/
            //this.RequiresAuthentication();
            
            
            /*** REPLACE ATTRIBUTES WITH METHOD CALLS ***/
            this.Get("/", this.GetFilms);
            this.Get("/{id:int}", this.GetFilmById);
            this.Put("/{id:int}", this.UpdateFilm);
            this.Post("/", this.CreateFilm);
            this.Delete("/{id:int}", this.DeleteFilm);
        }
        
        private async Task GetFilms(HttpContext context)
        {
            var handler = RouteHandlers.ListFilmsHandler;

            var films = handler();

            await context.Response.AsJson(films);
        }
        
        private async Task GetFilmById(HttpContext context)
        {
            var handler = RouteHandlers.ListFilmByIdHandler;

            var film = handler(context.GetRouteData().As<int>("id"));

            if (film == null)
            {
                context.Response.StatusCode = 404;
                return;
            }

            await context.Response.AsJson(film);
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

        private async Task CreateFilm(HttpContext context)
        {
            /*** REPLACE ATTRIBUTES WITH METHOD CALLS ***/
            var result = context.Request.BindAndValidate<Film>();

            if (!result.ValidationResult.IsValid)
            {
                context.Response.StatusCode = 422;
                await context.Response.Negotiate(result.ValidationResult.GetFormattedErrors());
                return;
            }

            try
            {
                var handler = RouteHandlers.CreateFilmHandler;

                handler(result.Data);

                context.Response.StatusCode = 201;
            }
            catch (Exception)
            {
                context.Response.StatusCode = 403;
            }
        }

        private Task DeleteFilm(HttpContext context)
        {
            try
            {
                var handler = RouteHandlers.DeleteFilmHandler;

                handler(context.GetRouteData().As<int>("id"));

                context.Response.StatusCode = 204;
            }
            catch (Exception)
            {
                context.Response.StatusCode = 403;
            }

            return Task.CompletedTask;
        }
    }
}
