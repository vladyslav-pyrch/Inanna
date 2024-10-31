using Inanna.Core.Domain.Model;
using Inanna.LibraryContext.Application.Features;
using Inanna.LibraryContext.Application.Features.Mangas.Projections.Repositories;
using Inanna.LibraryContext.Domain.Model.Mangas;
using Inanna.LibraryContext.Domain.Model.Shared;
using Inanna.LibraryContext.Infrastructure.DataAccess;
using Inanna.LibraryContext.Infrastructure.DataAccess.Mangas.Projections;
using Inanna.LibraryContext.Infrastructure.DataAccess.Mangas;
using Inanna.LibraryContext.Infrastructure.DataAccess.Mangas.Projections.Repositories;
using Inanna.LibraryContext.Infrastructure.FileSystemAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Inanna.LibraryContext.Infrastructure;

public static class InfrastructureModule
{
    public static void AddInfrastructureModule(this IServiceCollection services)
    {
        services.AddScoped<IMangaRepository, MangasRepository>();
        
        services.AddScoped<IEventStore, EventStore>();
        
        services.AddDbContext<MangasProjectionsDbContext>((provider, optionsBuilder) =>
        {
            var configuration = provider.GetRequiredService<IConfiguration>();
            string connectionString = configuration.GetConnectionString("ProjectionsDb") ?? throw new NullReferenceException();
            optionsBuilder.UseSqlServer(connectionString);
        });
        services.AddDbContext<EventStoreDbContext>((provider, optionsBuilder) =>
        {
            var configuration = provider.GetRequiredService<IConfiguration>();
            string connectionString = configuration.GetConnectionString("EventsDb") ?? throw new NullReferenceException();
            optionsBuilder.UseSqlServer(connectionString);
        });
        services.AddScoped<IChapterProjectionsRepository, ChapterProjectionsRepository>();
        services.AddScoped<IGenreProjectionsRepository, GenreProjectionsRepository>();
        services.AddScoped<IGenreToMangaProjectionsRepository, GenreToMangaProjectionsRepository>();
        services.AddScoped<IMangaProjectionsRepository, MangaProjectionsRepository>();
        services.AddScoped<IPageProjectionsRepository, PageProjectionsRepository>();
        services.AddScoped<IVolumeProjectionsRepository, VolumeProjectionsRepository>();
        services.AddScoped(typeof(IProjectionsRepository<>), typeof(DefaultProjectionsRepository<>));
            
        services.AddSingleton<IFileService, FileService>(provider =>
        {
            string? fileRootPath = provider.GetRequiredService<IConfiguration>()["FileRootPath"];
            ArgumentException.ThrowIfNullOrWhiteSpace(fileRootPath);
            Directory.CreateDirectory(fileRootPath);
            return new FileService(fileRootPath);
        });
    }
}