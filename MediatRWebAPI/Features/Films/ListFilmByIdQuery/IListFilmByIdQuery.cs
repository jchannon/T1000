namespace MediatRWebAPI.Features.Films.ListFilmByIdQuery
{
    using Models;

    public interface IListFilmByIdQuery
    {
        Film Execute(int id);
    }
}
