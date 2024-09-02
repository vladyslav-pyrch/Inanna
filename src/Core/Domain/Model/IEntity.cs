using MediatR;

namespace Inanna.Core.Domain.Model;

public interface IEntity<out TIdentity> where TIdentity : ValueObject, IIdentity
{
    public TIdentity Identity { get; }
    
    public void PublishDomainEvents(IMediator publisher);
}