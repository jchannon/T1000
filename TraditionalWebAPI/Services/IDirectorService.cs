namespace TraditionalWebAPI.Services
{
    using Models;

    public interface IDirectorService
    {
        Director ListDirectorById(int id);
        
        //Lots of other methods
    }
}