namespace Inanna.LibraryContext.Domain.Model.Mangas;

public interface IMangaRepository
{
    public Task<MangaId> Add(Manga manga);

    public Task SaveChanges(CancellationToken cancellationToken = default);
}