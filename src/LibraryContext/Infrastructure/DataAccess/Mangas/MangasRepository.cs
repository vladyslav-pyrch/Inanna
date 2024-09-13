using Inanna.Core.Domain.Model;
using Inanna.LibraryContext.Domain.Model.Mangas;

namespace Inanna.LibraryContext.Infrastructure.DataAccess.Mangas;

public class MangasRepository(IEventStore eventStore) : IMangaRepository
{
    public async Task<Manga> GetById(MangaId mangaId, CancellationToken cancellationToken = default)
    {
        var manga = new Manga();
        List<IEvent<MangaId>> events = await eventStore.RetrieveEvents(mangaId, cancellationToken);
        manga.Evolve(events);
        return manga;
    }
}