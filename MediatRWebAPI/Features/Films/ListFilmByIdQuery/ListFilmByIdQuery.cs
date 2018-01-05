namespace MediatRWebAPI.Features.Films.ListFilmByIdQuery
{
    using Models;

    public class ListFilmByIdQuery : IListFilmByIdQuery
    {
        public Film Execute(int id)
        {
            return new Film { Id = 1, Name = "Pulp Fiction", DirectorId = 1 };
        }
    }
}