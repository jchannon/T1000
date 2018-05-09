namespace HandRolledMediator
{
    using FluentValidation;
    using FluentValidation.AspNetCore;
    using HandRolledMediator.Features.CastMembers.GetCastByFilmIdQuery;
    using HandRolledMediator.Features.Directors.GetDirectorByIdQuery;
    using HandRolledMediator.Features.Films.CreateFilm;
    using HandRolledMediator.Features.Films.DeleteFilm;
    using HandRolledMediator.Features.Films.ListFilmById;
    using HandRolledMediator.Features.Films.ListFilmByIdQuery;
    using HandRolledMediator.Features.Films.ListFilms;
    using HandRolledMediator.Features.Films.UpdateFilm;
    using HandRolledMediator.Features.Permissions;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.DependencyInjection;
    using Models;

    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IGetCastByFilmIdQuery, GetCastByFilmIdQuery>();
            services.AddSingleton<IGetDirectorByIdQuery, GetDirectorByIdQuery>();
            services.AddSingleton<IValidUserQuery, ValidUserQuery>();
            services.AddSingleton<IListFilmByIdQuery, ListFilmByIdQuery>();
            
            services.AddSingleton(s => new Handler(new ICommandHandler[]
            {
                new CreateFilmCommandHandler(s.GetRequiredService<IValidUserQuery>()),
                new DeleteFilmCommandHandler(s.GetRequiredService<IValidUserQuery>()),
                new ListFilmsByIdCommandHandler(s.GetRequiredService<IListFilmByIdQuery>(), s.GetRequiredService<IGetDirectorByIdQuery>(), s.GetRequiredService<IGetCastByFilmIdQuery>()),
                new ListFilmsCommandHandler(), 
                new UpdateFilmCommandHandler(s.GetRequiredService<IListFilmByIdQuery>(),s.GetRequiredService<IValidUserQuery>()) 
            }));
            
            services.AddTransient<IValidator<Film>, FilmValidator>();

            services.AddMvc().AddFluentValidation();

        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseMvc();
        }
    }
}
