namespace BotwinMediator.Features.Films
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Botwin;
    using Botwin.ModelBinding;
    using Botwin.Request;
    using Botwin.Response;
    using BotwinMediator.Features.Films.CreateFilm;
    using BotwinMediator.Features.Films.DeleteFilm;
    using BotwinMediator.Features.Films.ListFilmById;
    using BotwinMediator.Features.Films.ListFilms;
    using BotwinMediator.Features.Films.UpdateFilm;
    using Models;

    public class FilmsModule : BotwinModule
    {
        private readonly Handler handler;

        public FilmsModule(Handler handler) : base("/api/films")
        {
            this.handler = handler;

            this.Get("/", async (request, response, routeData) =>
            {
                var command = new ListFilmsCommand();
                var films = this.handler.Execute<ListFilmsCommand, IEnumerable<Film>>(command);
                await response.AsJson(films);
            });

            this.Get("/{id:int}", async (request, response, routeData) =>
            {
                var command = new ListFilmsByIdCommand(routeData.As<int>("id"));

                var film = this.handler.Execute<ListFilmsByIdCommand, Film>(command);

                if (film == null)
                {
                    response.StatusCode = 404;
                    return;
                }

                await response.AsJson(film);
            });

            this.Post("/", async (req, res, routeData) =>
            {
                var result = req.BindAndValidate<Film>();

                if (!result.ValidationResult.IsValid)
                {
                    res.StatusCode = 422;
                    await res.Negotiate(result.ValidationResult.GetFormattedErrors());
                    return;
                }

                try
                {
                    var command = new CreateFilmCommand(result.Data);
                    this.handler.Handle(command);
                    res.StatusCode = 204;
                }
                catch (Exception)
                {
                    res.StatusCode = 403;
                }
            });

            this.Put("/{id:int}", async (req, res, routeData) =>
            {
                var result = req.BindAndValidate<Film>();

                if (!result.ValidationResult.IsValid)
                {
                    res.StatusCode = 422;
                    await res.Negotiate(result.ValidationResult.GetFormattedErrors());
                    return;
                }

                try
                {
                    var command = new UpdateFilmCommand(routeData.As<int>("id"), result.Data);
                    this.handler.Handle(command);
                    res.StatusCode = 204;
                }
                catch (Exception)
                {
                    res.StatusCode = 403;
                }
            });

            this.Delete("/{id:int}", (req, res, routeData) =>
            {
                try
                {
                    var command = new DeleteFilmCommand(routeData.As<int>("id"));
                    this.handler.Handle(command);
                    res.StatusCode = 204;
                }
                catch (Exception)
                {
                    res.StatusCode = 403;
                }

                return Task.CompletedTask;
            });
        }
    }
}
