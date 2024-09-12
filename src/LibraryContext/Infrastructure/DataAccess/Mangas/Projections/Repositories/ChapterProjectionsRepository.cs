using Inanna.LibraryContext.Application.Features;
using Inanna.LibraryContext.Application.Features.Mangas.Projections;
using Inanna.LibraryContext.Application.Features.Mangas.Projections.Repositories;

namespace Inanna.LibraryContext.Infrastructure.DataAccess.Mangas.Projections.Repositories;

public class ChapterProjectionsRepository : IChapterProjectionsRepository
{
    public Task<IQueryable<ChapterProjection>> Query()
    {
        throw new NotImplementedException();
    }

    public Task Create(ChapterProjection projection)
    {
        throw new NotImplementedException();
    }

    public Task Update(ChapterProjection projection)
    {
        throw new NotImplementedException();
    }

    public Task<ChapterProjection> Read(object projectionId)
    {
        throw new NotImplementedException();
    }

    public Task Delete(object projectionId)
    {
        throw new NotImplementedException();
    }
}