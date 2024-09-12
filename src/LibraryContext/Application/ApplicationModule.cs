using FluentValidation;
using Inanna.LibraryContext.Application.Features.Mangas;
using Inanna.LibraryContext.Application.PipelineBehaviours;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Inanna.LibraryContext.Application;

public static class ApplicationModule
{
    public static void AddApplicationModule(this IServiceCollection services)
    {
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(typeof(ApplicationModule).Assembly);
        });
        services.AddValidatorsFromAssembly(typeof(ApplicationModule).Assembly);
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        
        services.AddScoped<MangasProjectionsUnitOfWork>();
    }
}