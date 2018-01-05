namespace MediatRWebAPI.Features.Films
{
    using System;
    using System.Collections.Generic;
    using MediatR;
    using MediatRWebAPI.Features.Films.CreateFilm;
    using MediatRWebAPI.Features.Films.DeleteFilm;
    using MediatRWebAPI.Features.Films.ListFilmById;
    using MediatRWebAPI.Features.Films.ListFilms;
    using MediatRWebAPI.Features.Films.UpdateFilm;
    using Microsoft.AspNetCore.Mvc;
    using Models;

    [Route("api/[controller]")]
    public class FilmsController : Controller
    {
        private readonly IMediator mediator;

        public FilmsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // GET api/films
        [HttpGet]
        public IEnumerable<Film> Get()
        {
            var message = new ListFilmsMessage();

            return this.mediator.Send(message);
        }

        // GET api/films/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var message = new ListFilmsByIdMessage(id);

            var film = this.mediator.Send(message);

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
                var message = new CreateFilmMessage(film);
                this.mediator.Send(message);
            }
            catch (InvalidOperationException)
            {
                return StatusCode(403);
            }

            return StatusCode(201);
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
                var message = new UpdateFilmMessage(id, film);
                this.mediator.Send(message);
            }
            catch (InvalidOperationException)
            {
                return StatusCode(403);
            }

            return StatusCode(204);
        }

        // DELETE api/films/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var message = new DeleteFilmMessage(id);
                this.mediator.Send(message);
            }
            catch (InvalidOperationException)
            {
                return StatusCode(403);
            }

            return StatusCode(204);
        }
    }
}
