using MediatR;

namespace Inanna.Core.Domain.Model;

public interface IAggregateRoot<TIdentity> : IEntity<TIdentity> where TIdentity : AbstractIdentity
{
    public Task PublishEvents(IPublisher publisher);
    
    public void Evolve(IEnumerable<IEvent<TIdentity>> events);
}