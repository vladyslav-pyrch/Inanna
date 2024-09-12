using Inanna.Core.Domain.Model;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace Inanna.LibraryContext.Infrastructure.DataAccess;

public class EventStore(MongoClient client) : IEventStore
{
    public async Task<List<IDomainEvent<TIdentity>>> RetrieveEvents<TIdentity>(TIdentity aggregateRootId,
        CancellationToken cancellationToken = default) where TIdentity : AbstractIdentity
    {
        IMongoCollection<StoredEvent> collection = client.GetDatabase("InannaEventStore")
            .GetCollection<StoredEvent>("Events");
        IAsyncCursor<StoredEvent> cursor = await collection.FindAsync(@event => @event.AggregateRootId == aggregateRootId,
            cancellationToken: cancellationToken);
        List<StoredEvent> stagedEvents = await cursor.ToListAsync(cancellationToken: cancellationToken); 

        return stagedEvents.Select(@event => (IDomainEvent<TIdentity>)@event.Event)
            .OrderBy(@event => @event.OccuredOn)
            .ToList();
    }

    public async Task AppendEvent<TIdentity>(IDomainEvent<TIdentity> domainEvent,
        CancellationToken cancellationToken = default) where TIdentity : AbstractIdentity
    {
        IMongoCollection<StoredEvent> collection = client.GetDatabase("InannaEventStore")
            .GetCollection<StoredEvent>("Events");

        var storedEvent = new StoredEvent
        {
            Id = Guid.NewGuid(),
            AggregateRootId = domainEvent.AggregateRootId,
            OccuredOn = domainEvent.OccuredOn,
            Event = domainEvent
        };

        await collection.InsertOneAsync(storedEvent, cancellationToken: cancellationToken);
    }
}