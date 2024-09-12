using Azure.Core.Serialization;
using Inanna.Core.Domain.Model;
using Inanna.LibraryContext.Domain.Model.Mangas;
using Inanna.LibraryContext.Domain.Model.Shared;
using Inanna.LibraryContext.Infrastructure.DataAccess;
using Inanna.LibraryContext.Infrastructure.DataAccess.Repositories;
using Inanna.LibraryContext.Infrastructure.FileSystemAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using ObjectSerializer = MongoDB.Bson.Serialization.Serializers.ObjectSerializer;

namespace Inanna.LibraryContext.Infrastructure;

public static class InfrastructureModule
{
    public static void AddInfrastructureModule(this IServiceCollection services)
    {
        services.AddScoped<IEventStore, EventStore>();
        services.AddScoped<IMangaRepository, MangaRepository>();
        services.AddScoped<IMongoClient,MongoClient>(provider =>
        {
            var configuration = provider.GetRequiredService<IConfiguration>();
            string mongoDbConnectionString =
                configuration.GetConnectionString("EventsDb") ?? throw new Exception("No connection string with the name: EventsDb");
            BsonSerializer.RegisterSerializer(new ObjectSerializer(ObjectSerializer.AllAllowedTypes));
            var client = new MongoClient(mongoDbConnectionString);
            var sequence = new EventStore.Sequence();
            sequence.Insert(client.GetDatabase("InannaEventStore"));
            return client;
        });
        services.AddSingleton<IFileService, FileService>(provider =>
        {
            string? fileRootPath = provider.GetRequiredService<IConfiguration>()["FileRootPath"];
            ArgumentException.ThrowIfNullOrWhiteSpace(fileRootPath);
            Directory.CreateDirectory(fileRootPath);
            return new FileService(fileRootPath);
        });
    }
}