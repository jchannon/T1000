namespace FunctionalCarterProject
{
    using Carter;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.DependencyInjection;

    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddCarter(Assembly.GetCallingAssembly(), typeof(FilmValidator).Assembly);
            services.AddCarter();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseCarter();
        }
    }
}
