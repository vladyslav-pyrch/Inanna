using Inanna.LibraryContext.Domain.Model.Shared;
using Inanna.LibraryContext.Infrastructure.FileSystemAccess;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Inanna.LibraryContext.Infrastructure;

public static class InfrastructureModule
{
    public static void AddInfrastructureModule(this IServiceCollection services)
    {
        services.AddSingleton<IImageFileService, ImageFileService>(provider =>
        {
            string? imageRootPath = provider.GetRequiredService<IConfiguration>()["imageRootPath"];
            ArgumentException.ThrowIfNullOrWhiteSpace(imageRootPath);
            Directory.CreateDirectory(imageRootPath);
            return new ImageFileService(imageRootPath);
        });
    }
}