namespace TraditionalWebAPI.Services
{
    using System.Collections.Generic;
    using Models;

    public interface IDirectorService
    {
        IEnumerable<Director> ListAllDirectors();

        Director ListDirectorById(int id);
        
        //Lots of other methods
    }
}