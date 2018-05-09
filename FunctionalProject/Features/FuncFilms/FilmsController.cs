namespace FunctionalProject.Features.FuncFilms
{
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using Models;

    [Route("api/[controller]")]
    public class FilmsController : Controller
    {
        // GET api/films
        [HttpGet]
        public IEnumerable<Film> Get()
        {
            var handler = RouteHandlers.ListFilmsHandler;

            var films = handler();

            return films;
        }

        // GET api/films/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var handler = RouteHandlers.ListFilmByIdHandler;

            var film = handler(id);

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
                var handler = RouteHandlers.CreateFilmHandler;

                handler(film);
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
                var handler = RouteHandlers.UpdateFilmHandler;

                handler(id, film);
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
                var handler = RouteHandlers.DeleteFilmHandler;

                handler(id);
            }
            catch (InvalidOperationException)
            {
                return this.StatusCode(403);
            }

            return this.StatusCode(204);
        }
    }
}
