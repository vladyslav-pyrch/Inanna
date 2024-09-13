using Inanna.LibraryContext.Application.Features.Mangas.Projections;
using Inanna.LibraryContext.Application.Features.Mangas.Projections.Repositories;

namespace Inanna.LibraryContext.Infrastructure.DataAccess.Mangas.Projections.Repositories;

public class PageProjectionsRepository(MangasProjectionsDbContext dbContext) :
    DefaultProjectionsRepository<PageProjection>(dbContext), IPageProjectionsRepository;