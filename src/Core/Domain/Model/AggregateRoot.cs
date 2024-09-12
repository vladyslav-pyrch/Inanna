using MediatR;

namespace Inanna.Core.Domain.Model;

public abstract class AggregateRoot<TIdentity> : Entity<TIdentity>, IAggregateRoot<TIdentity>
    where TIdentity : AbstractIdentity
{
    private readonly Queue<IDomainEvent<TIdentity>> _domainEvents = [];
    
    public async Task PublishDomainEvents(IPublisher publisher)
    {
        while(_domainEvents.TryDequeue(out IDomainEvent<TIdentity>? domainEvent))
            await publisher.Publish(domainEvent);
    }

    public virtual void Evolve(IEnumerable<IDomainEvent<TIdentity>> domainEvents)
    {
        foreach (IDomainEvent<TIdentity> domainEvent in domainEvents)
            Evolve(domainEvent);
    }

    protected abstract void Evolve(IDomainEvent<TIdentity> domainEvent);

    protected void Enqueue(IDomainEvent<TIdentity> domainEvent)
    {
        BusynessRuleException.ThrowIfNull(domainEvent, "Domain event should not be equal to null");

        domainEvent.AggregateRootId = Identity;
        domainEvent.OccuredOn = DateTime.UtcNow;
        
        _domainEvents.Enqueue(domainEvent);
    }
}