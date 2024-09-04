using Inanna.LibraryContext.Domain.Model.Mangas;
using Inanna.LibraryContext.Infrastructure.DataAccess.Models;

namespace Inanna.LibraryContext.Infrastructure.DataAccess.Repositories;

public class MangaRepository(LibraryDbContext dbContext) : IMangaRepository
{
    public async Task<MangaId> Add(Manga manga)
    {
        var mangaModel = new MangaModel
        {
            Title = manga.Title,
            State = Enum.GetName(manga.State)!,
            PublisherId = manga.Publisher.Id,
            Cover = new ImageModel
            {
                Path = manga.Cover?.Path!,
                ContentType = manga.Cover?.ContentType!
            },
            Genres = manga.Genres.Select(genre => new GenreModel { Name = genre.Name }).ToList(),
            Volumes = []
        };

        await dbContext.Mangas.AddAsync(mangaModel);
        await SaveChanges();

        return new MangaId(mangaModel.Id);
    }

    public async Task SaveChanges(CancellationToken cancellationToken = default)
    {
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}