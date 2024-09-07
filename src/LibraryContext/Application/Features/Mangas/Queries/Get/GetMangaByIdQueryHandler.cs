using Inanna.LibraryContext.Application.DataAccess;
using Inanna.LibraryContext.Domain.Model.Mangas;
using Inanna.LibraryContext.Domain.Model.Mangas.Volumes;
using Inanna.LibraryContext.Domain.Model.Shared;
using Inanna.LibraryContext.Infrastructure.DataAccess.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Inanna.LibraryContext.Application.Features.Mangas.Queries.Get;

public class GetMangaByIdQueryHandler(LibraryDbContext dbContext) : IRequestHandler<GetMangaByIdQuery, Manga>
{
    public async Task<Manga> Handle(GetMangaByIdQuery request, CancellationToken cancellationToken)
    {
        MangaModel mangaModel = await dbContext.Mangas.AsNoTracking()
            .Include(model => model.Genres)
            .Include(model => model.Volumes)
            .FirstAsync(model => model.Id == request.MangaId.Value, cancellationToken);

        var mangaId = new MangaId(mangaModel.Id);
        var state = Enum.Parse<State>(mangaModel.State);
        var publisher = new Publisher(mangaModel.PublisherId);
        var cover = mangaModel.Cover is null ? null :
            new Image(mangaModel.Cover.Path, mangaModel.Cover.ContentType);
        var genres = mangaModel.Genres.Select(model => new Genre(model.Name)).ToList();
        var volumes = mangaModel.Volumes.Select(model => new VolumeId(model.Id)).ToList();

        return new Manga(mangaId, mangaModel.Title, state, publisher, cover, genres, volumes);
    }
}