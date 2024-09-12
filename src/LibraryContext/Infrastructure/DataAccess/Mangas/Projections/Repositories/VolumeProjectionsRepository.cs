using Inanna.LibraryContext.Application.Features;
using Inanna.LibraryContext.Application.Features.Mangas.Projections;
using Inanna.LibraryContext.Application.Features.Mangas.Projections.Repositories;

namespace Inanna.LibraryContext.Infrastructure.DataAccess.Mangas.Projections.Repositories;

public class VolumeProjectionsRepository : IVolumeProjectionsRepository
{
    public Task<IQueryable<VolumeProjection>> Query()
    {
        throw new NotImplementedException();
    }

    public Task Create(VolumeProjection projection)
    {
        throw new NotImplementedException();
    }

    public Task Update(VolumeProjection projection)
    {
        throw new NotImplementedException();
    }

    public Task<VolumeProjection> Read(object projectionId)
    {
        throw new NotImplementedException();
    }

    public Task Delete(object projectionId)
    {
        throw new NotImplementedException();
    }
}