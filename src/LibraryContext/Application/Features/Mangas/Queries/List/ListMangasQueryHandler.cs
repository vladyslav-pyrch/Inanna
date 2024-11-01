using Inanna.Core.Messaging;
using Inanna.LibraryContext.Application.Features.Mangas.Projections;

namespace Inanna.LibraryContext.Application.Features.Mangas.Queries.List;

public class ListMangasQueryHandler(MangasProjectionsUnitOfWork unitOfWork) : IQueryHandler<ListMangasQuery, List<MangaProjection>>
{
    public Task<List<MangaProjection>> Handle(ListMangasQuery request, CancellationToken cancellationToken)
    {
        List<MangaProjection> mangaProjections = unitOfWork.MangaProjections.Query().ToList();

        return Task.FromResult(mangaProjections);
    }
}