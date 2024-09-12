namespace Inanna.Core.Domain.Model;

public interface IEventStore
{
    public Task<List<IDomainEvent<TIdentity>>> RetrieveEvents<TIdentity>(TIdentity aggregateRootId,
        CancellationToken cancellationToken = default)
        where TIdentity : AbstractIdentity;

    public Task AppendEvent<TIdentity>(IDomainEvent<TIdentity> domainEvent,
        CancellationToken cancellationToken = default) where TIdentity : AbstractIdentity;

}