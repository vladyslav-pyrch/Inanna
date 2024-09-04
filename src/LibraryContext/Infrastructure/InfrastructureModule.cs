using Inanna.LibraryContext.Domain.Model.Mangas;
using Inanna.LibraryContext.Domain.Model.Shared;
using Inanna.LibraryContext.Infrastructure.DataAccess;
using Inanna.LibraryContext.Infrastructure.DataAccess.Repositories;
using Inanna.LibraryContext.Infrastructure.FileSystemAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Inanna.LibraryContext.Infrastructure;

public static class InfrastructureModule
{
    public static void AddInfrastructureModule(this IServiceCollection services)
    {
        services.AddDbContext<LibraryDbContext>((provider, optionsBuilder) =>
        {
            var configuration = provider.GetRequiredService<IConfiguration>();
            string connectionString = configuration.GetConnectionString("Database") ?? throw new NullReferenceException();
            optionsBuilder.UseSqlServer(connectionString);
        });
        services.AddScoped<IMangaRepository, MangaRepository>();
        services.AddSingleton<IImageFileService, ImageFileService>(provider =>
        {
            string? imageRootPath = provider.GetRequiredService<IConfiguration>()["imageRootPath"];
            ArgumentException.ThrowIfNullOrWhiteSpace(imageRootPath);
            Directory.CreateDirectory(imageRootPath);
            return new ImageFileService(imageRootPath);
        });
    }
}