namespace Inanna.Core.Domain.Model;

public interface IDomainEventHandler<in TDomainEvent> where TDomainEvent : IDomainEvent
{
    public Task Handle(TDomainEvent domainEvent);
}