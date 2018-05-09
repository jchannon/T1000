namespace FunctionalCarterProject.Features.NamedDelegatesFilms.Films
{
    using FunctionalCarterProject.Features.NamedDelegatesFilms.CastMembers;
    using FunctionalCarterProject.Features.NamedDelegatesFilms.Directors;
    using FunctionalCarterProject.Features.NamedDelegatesFilms.Films.CreateFilm;
    using FunctionalCarterProject.Features.NamedDelegatesFilms.Films.DeleteFilm;
    using FunctionalCarterProject.Features.NamedDelegatesFilms.Films.ListFilmById;
    using FunctionalCarterProject.Features.NamedDelegatesFilms.Films.ListFilms;
    using FunctionalCarterProject.Features.NamedDelegatesFilms.Films.Permissions;
    using FunctionalCarterProject.Features.NamedDelegatesFilms.Films.UpdateFilm;

    public static class RouteHandlers
    {
        public static CreateFilmDelegate CreateFilmHandler;

        public static ListFilmByIdDelegate ListFilmByIdHandler;

        public static DeleteFilmDelegate DeleteFilmHandler;

        public static ListFilmsDelegate ListFilmsHandler;

        public static UpdateFilmDelegate UpdateFilmHandler;
        
        static RouteHandlers()
        {
            CreateFilmHandler = film => CreateFilmRoute.Handle(film, () => ValidUserQuery.Execute());

            DeleteFilmHandler = id => DeleteFilmRoute.Handle(id, () => ValidUserQuery.Execute());
            
            ListFilmByIdHandler = id => ListFilmByIdRoute.Handle(
                id,
                filmId => ListFilmsByIdQuery.ListFilmsByIdQuery.Execute(id),
                dirId => GetDirectorByIdQuery.Execute(dirId),
                filmId => GetCastByFilmIdQuery.Execute(id)
            );

            ListFilmsHandler = () => ListFilmsRoute.Handle();

            UpdateFilmHandler = (id, film) => UpdateFilmRoute.Handle(
                id, 
                film, 
                () => ValidUserQuery.Execute(), 
                filmId => ListFilmsByIdQuery.ListFilmsByIdQuery.Execute(filmId));
        }
    }
}
