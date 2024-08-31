using MediatR;

namespace Inanna.Core.Domain.Model;

public abstract class Entity<TIdentity> : IEntity<TIdentity> where TIdentity : ValueObject, IIdentity
{
    private readonly List<IDomainEvent> _domainEvents = [];

    protected Entity(TIdentity identity)
    {
        Id = identity;
    }

    public TIdentity Id { get; }
    
    public void PublishDomainEvents(IMediator publisher)
    {
        foreach (IDomainEvent domainEvent in _domainEvents)
            publisher.Publish(domainEvent);

        ResetDomainEvents();
    }

    protected void AddDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    protected string AggregateSource() => GetType().Name;

    private void ResetDomainEvents()
    {
        _domainEvents.Clear();
    }
}