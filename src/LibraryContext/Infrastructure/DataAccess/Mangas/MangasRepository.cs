using Inanna.Core.Domain.Model;
using Inanna.LibraryContext.Domain.Model.Mangas;

namespace Inanna.LibraryContext.Infrastructure.DataAccess.Mangas;

public class MangasRepository(IEventStore eventStore) : IMangaRepository
{
    public async Task<Manga> GetById(MangaId mangaId, CancellationToken cancellationToken = default)
    {
        var manga = new Manga();
        List<IDomainEvent<MangaId>> domainEvents = await eventStore.RetrieveEvents(mangaId, cancellationToken);
        manga.Evolve(domainEvents);
        return manga;
    }
}