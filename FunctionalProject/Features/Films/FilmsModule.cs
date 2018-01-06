namespace FunctionalProject.Features.Films
{
    using System.Threading.Tasks;
    using Botwin;
    using Botwin.Response;
    using Microsoft.AspNetCore.Http;

    public class FilmsModule : BotwinModule
    {
        public FilmsModule() : base("/api/films")
        {
            this.Get("/", GetFilms);
        }

        private async Task GetFilms(HttpContext context)
        {
            
        }
    }
}
