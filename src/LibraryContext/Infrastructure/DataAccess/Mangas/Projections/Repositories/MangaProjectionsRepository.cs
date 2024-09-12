using Inanna.LibraryContext.Application.Features;
using Inanna.LibraryContext.Application.Features.Mangas.Projections;
using Inanna.LibraryContext.Application.Features.Mangas.Projections.Repositories;

namespace Inanna.LibraryContext.Infrastructure.DataAccess.Mangas.Projections.Repositories;

public class MangaProjectionsRepository : IMangaProjectionsRepository
{
    public Task<IQueryable<MangaProjection>> Query()
    {
        throw new NotImplementedException();
    }

    public Task Create(MangaProjection projection)
    {
        throw new NotImplementedException();
    }

    public Task Update(MangaProjection projection)
    {
        throw new NotImplementedException();
    }

    public Task<MangaProjection> Read(object projectionId)
    {
        throw new NotImplementedException();
    }

    public Task Delete(object projectionId)
    {
        throw new NotImplementedException();
    }
}