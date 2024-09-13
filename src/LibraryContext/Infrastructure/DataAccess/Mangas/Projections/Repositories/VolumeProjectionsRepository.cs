using Inanna.LibraryContext.Application.Features.Mangas.Projections;
using Inanna.LibraryContext.Application.Features.Mangas.Projections.Repositories;

namespace Inanna.LibraryContext.Infrastructure.DataAccess.Mangas.Projections.Repositories;

public class VolumeProjectionsRepository(MangasProjectionsDbContext dbContext) :
    DefaultProjectionsRepository<VolumeProjection>(dbContext), IVolumeProjectionsRepository;