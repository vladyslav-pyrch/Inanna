namespace Inanna.Core.Domain.Model;

public interface IDomainEventPublisher
{
    public Task Stage(IDomainEvent domainEvent);

    public Task Commit();

    public Task Publish<TDomainEvent>(TDomainEvent domainEvent) where TDomainEvent : IDomainEvent;
    public Task Register<TDomainEvent>(IDomainEventHandler<TDomainEvent> handler) where TDomainEvent : IDomainEvent;

    public Task Register<TDomainEvent>(Func<TDomainEvent, Task> handler) where TDomainEvent : IDomainEvent;
}