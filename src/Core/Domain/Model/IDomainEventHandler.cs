using MediatR;

namespace Inanna.Core.Domain.Model;

public interface IDomainEventHandler<in TDomainEvent> : INotificationHandler<TDomainEvent> where TDomainEvent : IDomainEvent;