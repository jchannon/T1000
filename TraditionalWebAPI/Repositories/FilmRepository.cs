namespace TraditionalWebAPI.Repositories
{
    using System.Collections.Generic;
    using Models;

    public class FilmRepository : IFilmRepository
    {
        public IEnumerable<Film> ListFilms()
        {
            return new[] { new Film { Id = 1, Name = "Pulp Fiction" }, new Film { Id = 2, Name = "Trainspotting" } };
        }

        public Film ListFilmById(int id)
        {
            return new Film { Id = 1, Name = "Pulp Fiction", DirectorId = 1};
        }

        public void CreateFilm(Film film)
        {
            //Save to DB
        }

        public void UpdateFilm(Film existingFilm)
        {
            //Update DB
        }

        public void DeleteFilm(int id)
        {
            //Delete from DB
        }
    }
}