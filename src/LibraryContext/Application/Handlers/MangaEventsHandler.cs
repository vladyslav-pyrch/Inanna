using Inanna.Core.Domain.Model;
using Inanna.LibraryContext.Domain.Model.Mangas;

namespace Inanna.LibraryContext.Application.Handlers;

public class MangaEventsHandler<TDomainEvent>(IEventStore eventStore) : IDomainEventHandler<TDomainEvent, MangaId>
    where TDomainEvent : IDomainEvent<MangaId>
{
    public async Task Handle(TDomainEvent notification, CancellationToken cancellationToken) =>
        await eventStore.AppendEvent(notification, cancellationToken);
}