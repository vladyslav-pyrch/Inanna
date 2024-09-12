using FluentValidation;
using Inanna.Core.Domain.Model;
using Inanna.LibraryContext.Application.DataAccess;
using Inanna.LibraryContext.Application.Handlers;
using Inanna.LibraryContext.Application.PipelineBehaviours;
using Inanna.LibraryContext.Domain.Model.Mangas;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Inanna.LibraryContext.Application;

public static class ApplicationModule
{
    public static void AddApplicationModule(this IServiceCollection services)
    {
        services.AddDbContext<LibraryDbContext>((provider, optionsBuilder) =>
        {
            var configuration = provider.GetRequiredService<IConfiguration>();
            string connectionString = configuration.GetConnectionString("ProjectionsDb") ?? throw new NullReferenceException();
            optionsBuilder.UseSqlServer(connectionString);
        });
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(typeof(ApplicationModule).Assembly);
        });
        // services.AddScoped(typeof(INotificationHandler<>), typeof(MangaEventsHandler<>));
        services.AddValidatorsFromAssembly(typeof(ApplicationModule).Assembly);
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
    }
}