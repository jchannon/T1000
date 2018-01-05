namespace MediatRWebAPI
{
    using System;
    using System.Collections.Generic;
    using FluentValidation;
    using FluentValidation.AspNetCore;
    using MediatR;
    using MediatRWebAPI.Features.CastMembers.GetCastByFilmIdQuery;
    using MediatRWebAPI.Features.Directors.GetDirectorByIdQuery;
    using MediatRWebAPI.Features.Films.ListFilmById;
    using MediatRWebAPI.Features.Films.ListFilms;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Models;

    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IGetCastByFilmIdQuery, GetCastByFilmIdQuery>();
            services.AddSingleton<IGetDirectorByIdQuery, GetDirectorByIdQuery>();
            
            services.AddSingleton<IRequestHandler<ListFilmsByIdMessage, Film>, ListFilmsByIdMessageHandler>();
            services.AddSingleton<IRequestHandler<ListFilmsMessage, IEnumerable<Film>>, ListFilmsMessageHandler>();
            
            services.AddScoped<SingleInstanceFactory>(p => p.GetRequiredService);
            services.AddScoped<MultiInstanceFactory>(p => p.GetRequiredServices);
            services.AddSingleton<IMediator, Mediator>();
            
            services.AddTransient<IValidator<Film>, FilmValidator>();
            
            services.AddMvc().AddFluentValidation();
            
           
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseMvc();
        }
        
       
    }

    public static class Foo
    {
        public static IEnumerable<object> GetRequiredServices(this IServiceProvider provider, Type serviceType)
        {
            return (IEnumerable<object>) provider.GetRequiredService(typeof(IEnumerable<>).MakeGenericType(serviceType));
        } 
    }
}
