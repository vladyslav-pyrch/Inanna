using MediatR;

namespace Inanna.Core.Domain.Model;

public abstract class AggregateRoot<TIdentity> : Entity<TIdentity>, IAggregateRoot<TIdentity>
    where TIdentity : AbstractIdentity
{
    private readonly Queue<IEvent<TIdentity>> _events = [];
    
    public async Task PublishDomainEvents(IPublisher publisher)
    {
        while(_events.TryDequeue(out IEvent<TIdentity>? @event))
            await publisher.Publish(@event);
    }

    public virtual void Evolve(IEnumerable<IEvent<TIdentity>> events)
    {
        foreach (IEvent<TIdentity> @event in events)
            Evolve(@event);
    }

    protected abstract void Evolve(IEvent<TIdentity> domainEvent);

    protected void Enqueue(IEvent<TIdentity> domainEvent)
    {
        BusynessRuleException.ThrowIfNull(domainEvent, "Domain event should not be equal to null");

        domainEvent.AggregateRootId = Identity;
        domainEvent.OccuredOn = DateTime.UtcNow;
        
        _events.Enqueue(domainEvent);
    }
}