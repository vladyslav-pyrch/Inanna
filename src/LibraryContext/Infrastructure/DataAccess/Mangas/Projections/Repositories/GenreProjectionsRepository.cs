using Inanna.LibraryContext.Application.Features;
using Inanna.LibraryContext.Application.Features.Mangas.Projections;
using Inanna.LibraryContext.Application.Features.Mangas.Projections.Repositories;

namespace Inanna.LibraryContext.Infrastructure.DataAccess.Mangas.Projections.Repositories;

public class GenreProjectionsRepository : IGenreProjectionsRepository
{
    public Task<IQueryable<GenreProjection>> Query()
    {
        throw new NotImplementedException();
    }

    public Task Create(GenreProjection projection)
    {
        throw new NotImplementedException();
    }

    public Task Update(GenreProjection projection)
    {
        throw new NotImplementedException();
    }

    public Task<GenreProjection> Read(object projectionId)
    {
        throw new NotImplementedException();
    }

    public Task Delete(object projectionId)
    {
        throw new NotImplementedException();
    }
}