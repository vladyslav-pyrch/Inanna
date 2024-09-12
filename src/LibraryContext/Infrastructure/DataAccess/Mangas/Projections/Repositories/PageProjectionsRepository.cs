using Inanna.LibraryContext.Application.Features;
using Inanna.LibraryContext.Application.Features.Mangas.Projections;
using Inanna.LibraryContext.Application.Features.Mangas.Projections.Repositories;

namespace Inanna.LibraryContext.Infrastructure.DataAccess.Mangas.Projections.Repositories;

public class PageProjectionsRepository : IPageProjectionsRepository
{
    public Task<IQueryable<PageProjection>> Query()
    {
        throw new NotImplementedException();
    }

    public Task Create(PageProjection projection)
    {
        throw new NotImplementedException();
    }

    public Task Update(PageProjection projection)
    {
        throw new NotImplementedException();
    }

    public Task<PageProjection> Read(object projectionId)
    {
        throw new NotImplementedException();
    }

    public Task Delete(object projectionId)
    {
        throw new NotImplementedException();
    }
}