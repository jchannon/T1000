namespace BotwinMediator
{
    using System.Reflection;
    using Botwin;
    using BotwinMediator.Features.CastMembers.GetCastByFilmIdQuery;
    using BotwinMediator.Features.Directors.GetDirectorByIdQuery;
    using BotwinMediator.Features.Films.CreateFilm;
    using BotwinMediator.Features.Films.DeleteFilm;
    using BotwinMediator.Features.Films.ListFilmById;
    using BotwinMediator.Features.Films.ListFilmByIdQuery;
    using BotwinMediator.Features.Films.ListFilms;
    using BotwinMediator.Features.Films.UpdateFilm;
    using BotwinMediator.Features.Permissions;
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

            services.AddBotwin(Assembly.GetCallingAssembly(), typeof(FilmValidator).Assembly);
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseBotwin();
        }
    }
}
