using MediatR;

namespace Inanna.Core.Domain.Model;

public interface IDomainEvent : INotification; 

public interface IDomainEvent<TIdentity> : IDomainEvent where TIdentity : AbstractIdentity 
{
    public TIdentity AggregateRootId { get; internal set; }
    
    public DateTime OccuredOn { get; internal set; }

}