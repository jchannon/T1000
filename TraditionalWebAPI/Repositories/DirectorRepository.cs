namespace TraditionalWebAPI.Repositories
{
    using System.Collections.Generic;
    using Models;

    public class DirectorRepository : IDirectorRepository
    {
        public IEnumerable<Director> ListAllDirectors()
        {
            throw new System.NotImplementedException();
        }

        public Director ListDirectorById(int id)
        {
            return new Director { Name = "Steven Spielberg" };
        }
    }
}