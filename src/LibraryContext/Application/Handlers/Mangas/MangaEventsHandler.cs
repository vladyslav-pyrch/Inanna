using Inanna.Core.Domain.Model;
using Inanna.LibraryContext.Domain.Model.Mangas;

namespace Inanna.LibraryContext.Application.Handlers.Mangas;

public class MangaEventsHandler<TEvent>(IEventStore eventStore) : IEventHandler<TEvent, MangaId>
    where TEvent : IEvent<MangaId>
{
    public async Task Handle(TEvent @event, CancellationToken cancellationToken) =>
        await eventStore.AppendEvent(@event, cancellationToken);
}