using System.Collections.Concurrent;

namespace Inanna.Core.Domain.Model;

public sealed class DomainEventPublisher : IDomainEventPublisher
{
    private ConcurrentBag<IDomainEvent> _stagedDomainEvents = [];

    private readonly ConcurrentBag<Subscriber> _subscribers = [];
    
    private bool IsPublishing { get; set; }
    
    public Task Stage(IDomainEvent domainEvent)
    {
        _stagedDomainEvents.Add(domainEvent);
        return Task.CompletedTask;
    }

    public async Task Commit()
    {
        foreach (IDomainEvent stagedDomainEvent in _stagedDomainEvents)
            await Publish(stagedDomainEvent);
        
        Interlocked.Exchange(ref _stagedDomainEvents, []);
    }

    public Task Publish<TDomainEvent>(TDomainEvent domainEvent) where TDomainEvent : IDomainEvent
    {
        if (!HasSubscribers())
            return Task.CompletedTask;

        try
        {
            StartPublishing();

             _subscribers.Where(subscriber => subscriber.SubscribedTo == typeof(TDomainEvent) ||
                                              typeof(TDomainEvent).IsSubclassOf(subscriber.SubscribedTo))
                .Select(subscriber => (IDomainEventHandler<TDomainEvent>)subscriber.Handler)
                .ToList().ForEach(handler => handler.Handle(domainEvent));
        }
        finally
        {
            StopPublishing();
        }
        
        return Task.CompletedTask;
    }

    public Task Register<TDomainEvent>(IDomainEventHandler<TDomainEvent> handler) where TDomainEvent : IDomainEvent
    {
        var subscriber = new Subscriber(typeof(TDomainEvent), handler);

        if (_subscribers.Contains(subscriber) || IsPublishing)
            return Task.FromException(
                new InvalidOperationException("Cannot register a handler while publishing or if already registered."));
        
        _subscribers.Add(subscriber);
        
        return Task.CompletedTask;
    }

    public Task Register<TDomainEvent>(Func<TDomainEvent, Task> handler) where TDomainEvent : IDomainEvent
    {
        return Register(new InternalDomainEventHandler<TDomainEvent>(handler));
    }

    private void StartPublishing() => IsPublishing = true;

    private void StopPublishing() => IsPublishing = false;

    private bool HasSubscribers() => !_subscribers.IsEmpty;

    private record Subscriber(Type SubscribedTo, object Handler);
    
    private sealed class InternalDomainEventHandler<TDomainEvent>(Func<TDomainEvent, Task> handle)
        : IDomainEventHandler<TDomainEvent>
        where TDomainEvent : IDomainEvent
    {
        public async Task Handle(TDomainEvent domainEvent) => await handle(domainEvent);
    }
}