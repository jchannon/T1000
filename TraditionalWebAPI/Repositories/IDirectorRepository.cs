namespace TraditionalWebAPI.Repositories
{
    using System.Collections.Generic;
    using Models;

    public interface IDirectorRepository
    {
        IEnumerable<Director> ListAllDirectors();

        Director ListDirectorById(int id);
    }
}
