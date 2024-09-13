using MediatR;

namespace Inanna.Core.Domain.Model;

public interface IEventHandler<in TEvent, TIdentity> : INotificationHandler<TEvent> 
    where TEvent : IEvent<TIdentity>
    where TIdentity : AbstractIdentity;