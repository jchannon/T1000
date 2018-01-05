namespace TraditionalWebAPI
{
    using FluentValidation;
    using FluentValidation.AspNetCore;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Models;
    using TraditionalWebAPI.Controllers;
    using TraditionalWebAPI.Repositories;
    using TraditionalWebAPI.Services;

    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IFilmRepository, FilmRepository>();
            services.AddSingleton<IDirectorRepository, DirectorRepository>();
            services.AddSingleton<ICastMemberRepository, CastMemberRepository>();

            services.AddSingleton<IFilmService, FilmService>();
            services.AddSingleton<IDirectorService, DirectorService>();
            services.AddSingleton<ICastMemberService, CastMemberService>();

            services.AddSingleton<IPermissionService, PermissionService>();

            services.AddTransient<IValidator<Film>, FilmValidator>();

            services.AddMvc().AddFluentValidation();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseMvc();
        }
    }
}
