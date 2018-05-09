namespace FunctionalCarterProject.Features.NamedDelegatesFilms.Films
{
    using System.Collections.Generic;
    using Models;

    public delegate Film ListFilmByIdDelegate(int id);

    public delegate void CreateFilmDelegate(Film film);

    public delegate void DeleteFilmDelegate(int id);

    public delegate IEnumerable<Film> ListFilmsDelegate();

    public delegate void UpdateFilmDelegate(int id, Film film);
    
    public delegate bool ValidUserDelegate();
    
    public delegate Director GetDirectorByIdDelegate(int id);
    
    public delegate IEnumerable<CastMember> GetCastByFilmIdDelegate(int filmId);
}
