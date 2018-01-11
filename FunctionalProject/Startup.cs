namespace FunctionalProject
{
    using System.Reflection;
    using Botwin;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.DependencyInjection;
    using Models;

    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddBotwin(Assembly.GetCallingAssembly(), typeof(FilmValidator).Assembly);
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseBotwin();
        }
    }
}
