using MediatR;

namespace Inanna.Core.Domain.Model;

public interface IDomainEventHandler<in TDomainEvent, out TIdentity> : INotificationHandler<TDomainEvent> 
    where TDomainEvent : IDomainEvent<TIdentity>
    where TIdentity : AbstractIdentity;