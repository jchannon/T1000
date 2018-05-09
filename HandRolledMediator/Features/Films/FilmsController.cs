namespace HandRolledMediator.Features.Films
{
    using System;
    using System.Collections.Generic;
    using HandRolledMediator.Features.Films.CreateFilm;
    using HandRolledMediator.Features.Films.DeleteFilm;
    using HandRolledMediator.Features.Films.ListFilmById;
    using HandRolledMediator.Features.Films.ListFilms;
    using HandRolledMediator.Features.Films.UpdateFilm;
    using Microsoft.AspNetCore.Mvc;
    using Models;

    [Route("api/[controller]")]
    public class FilmsController : Controller
    {
        private readonly Handler handler;

        public FilmsController(Handler handler)
        {
            this.handler = handler;
        }

        // GET api/films
        [HttpGet]
        public IEnumerable<Film> Get()
        {
            var command = new ListFilmsCommand();
            return this.handler.Execute<ListFilmsCommand, IEnumerable<Film>>(command);
        }

        // GET api/films/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var command = new ListFilmsByIdCommand(id);

            var film = this.handler.Execute<ListFilmsByIdCommand, Film>(command);

            if (film == null)
            {
                return this.NotFound();
            }

            return this.Ok(film);
        }

        // POST api/films
        [HttpPost]
        public IActionResult Post([FromBody] Film film)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            try
            {
                var command = new CreateFilmCommand(film);
                this.handler.Handle(command);
            }
            catch (InvalidOperationException)
            {
                return this.StatusCode(403);
            }

            return this.StatusCode(201);
        }

        // PUT api/films/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Film film)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            try
            {
                var command = new UpdateFilmCommand(id, film);
                this.handler.Handle(command);
            }
            catch (InvalidOperationException)
            {
                return this.StatusCode(403);
            }

            return this.StatusCode(204);
        }

        // DELETE api/films/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var command = new DeleteFilmCommand(id);
                this.handler.Handle(command);
            }
            catch (InvalidOperationException)
            {
                return this.StatusCode(403);
            }

            return this.StatusCode(204);
        }
    }
}
