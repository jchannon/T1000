namespace FunctionalCarterProject.Features.NamedDelegatesFilms.Films.ListFilmsByIdQuery
{
    using Models;

    public static class ListFilmsByIdQuery
    {
        public static Film Execute(int id)
        {
            return new Film { Id = 1, Name = "Pulp Fiction", DirectorId = 1 };
        }
    }
}
