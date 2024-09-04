using System.Reflection;
using FluentValidation;
using Inanna.LibraryContext.Application.PipelineBehaviours;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Inanna.LibraryContext.Application;

public static class ApplicationModule
{
    public static void AddApplicationModule(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(typeof(ApplicationModule).Assembly);
        });
        serviceCollection.AddValidatorsFromAssembly(typeof(ApplicationModule).Assembly);
        serviceCollection.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
    }
}