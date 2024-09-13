using MediatR;

namespace Inanna.Core.Domain.Model;

public interface IAggregateRoot<TIdentity> : IEntity<TIdentity> where TIdentity : AbstractIdentity
{
    public Task PublishDomainEvents(IPublisher publisher);
    
    public void Evolve(IEnumerable<IEvent<TIdentity>> events);
}