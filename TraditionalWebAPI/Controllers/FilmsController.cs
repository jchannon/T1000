namespace TraditionalWebAPI.Controllers
{
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using TraditionalWebAPI.Services;

    [AllowAnonymous]
    [Route("api/[controller]")]
    public class FilmsController : Controller
    {
        private readonly IFilmService filmService;

        public FilmsController(IFilmService filmService)
        {
            this.filmService = filmService;
        }

        // GET api/films
        [HttpGet]
        public IEnumerable<Film> Get()
        {
            return this.filmService.ListFilms();
        }

        // GET api/films/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var film = this.filmService.ListFilmById(id);
            if (film == null)
            {
                return this.NotFound();
            }

            return Ok(film);
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
                this.filmService.CreateFilm(film);
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
                this.filmService.UpdateFilm(id, film);
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
                this.filmService.DeleteFilm(id);
            }
            catch (InvalidOperationException)
            {
                return StatusCode(403);
            }

            return StatusCode(204);
        }
    }
}
