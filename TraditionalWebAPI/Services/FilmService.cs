namespace TraditionalWebAPI.Services
{
    using System;
    using System.Collections.Generic;
    using Models;
    using TraditionalWebAPI.Repositories;

    public class FilmService : IFilmService
    {
        private readonly IFilmRepository filmRepository;

        private readonly IDirectorService directorService;

        private readonly ICastMemberService castMemberService;

        private readonly IPermissionService permissionService;

        public FilmService(IFilmRepository filmRepository, IDirectorService directorService, ICastMemberService castMemberService, IPermissionService permissionService)
        {
            this.filmRepository = filmRepository;
            this.directorService = directorService;
            this.castMemberService = castMemberService;
            this.permissionService = permissionService;
        }

        public IEnumerable<Film> ListFilms()
        {
            return this.filmRepository.ListFilms();
        }

        public Film ListFilmById(int id)
        {
            var film = this.filmRepository.ListFilmById(id);

            var director = this.directorService.ListDirectorById(film.DirectorId);
            film.Director = director;

            var cast = this.castMemberService.ListCastMembersByFilmId(id);
            film.Cast = cast;

            return film;
        }

        public void CreateFilm(Film film)
        {
            if (!this.permissionService.ValidUser())
            {
                throw new InvalidOperationException();
            }
            
            //Do some special MEGA CORP business validation

            this.filmRepository.CreateFilm(film);
        }

        public void UpdateFilm(int id, Film film)
        {
            if (!this.permissionService.ValidUser())
            {
                throw new InvalidOperationException();
            }
            
            //Do some special MEGA CORP business validation
            
            var existingFilm = this.filmRepository.ListFilmById(id);

            existingFilm.Name = film.Name;
            existingFilm.Budget = film.Budget;
            existingFilm.Language = film.Language;

            this.filmRepository.UpdateFilm(existingFilm);
        }

        public void DeleteFilm(int id)
        {
            if (!this.permissionService.ValidUser())
            {
                throw new InvalidOperationException();
            }

            this.filmRepository.DeleteFilm(id);
        }
    }
}
