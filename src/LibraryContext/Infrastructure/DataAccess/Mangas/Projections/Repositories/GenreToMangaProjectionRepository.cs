using Inanna.LibraryContext.Application.Features;
using Inanna.LibraryContext.Application.Features.Mangas.Projections;
using Inanna.LibraryContext.Application.Features.Mangas.Projections.Repositories;

namespace Inanna.LibraryContext.Infrastructure.DataAccess.Mangas.Projections.Repositories;

public class GenreToMangaProjectionsRepository : IGenreToMangaProjectionsRepository
{
    public Task<IQueryable<GenreToMangaProjection>> Query()
    {
        throw new NotImplementedException();
    }

    public Task Create(GenreToMangaProjection projection)
    {
        throw new NotImplementedException();
    }

    public Task Update(GenreToMangaProjection projection)
    {
        throw new NotImplementedException();
    }

    public Task<GenreToMangaProjection> Read(object projectionId)
    {
        throw new NotImplementedException();
    }

    public Task Delete(object projectionId)
    {
        throw new NotImplementedException();
    }
}