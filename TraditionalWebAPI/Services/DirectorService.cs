namespace TraditionalWebAPI.Services
{
    using Models;
    using TraditionalWebAPI.Repositories;

    public class DirectorService : IDirectorService
    {
        private readonly IDirectorRepository directorRepository;

        public DirectorService(IDirectorRepository directorRepository)
        {
            this.directorRepository = directorRepository;
        }

        public Director ListDirectorById(int id)
        {
            return this.directorRepository.ListDirectorById(id);
        }
    }
}
