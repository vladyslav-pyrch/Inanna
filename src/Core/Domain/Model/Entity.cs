using MediatR;

namespace Inanna.Core.Domain.Model;

public abstract class Entity<TIdentity> : IEntity<TIdentity> where TIdentity : ValueObject, IIdentity
{
    private readonly TIdentity _identity;
    
    private readonly List<IDomainEvent> _domainEvents = [];

    protected Entity(TIdentity identity)
    {
        Identity = identity;
    }

    public TIdentity Identity
    {
        get => _identity;
        private init => _identity = value ?? throw new BusynessRuleException("Identity cannot be null.");
    }
    
    public void PublishDomainEvents(IPublisher publisher)
    {
        foreach (IDomainEvent domainEvent in _domainEvents)
            publisher.Publish(domainEvent);

        ResetDomainEvents();
    }

    protected void AddDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    private void ResetDomainEvents()
    {
        _domainEvents.Clear();
    }
}