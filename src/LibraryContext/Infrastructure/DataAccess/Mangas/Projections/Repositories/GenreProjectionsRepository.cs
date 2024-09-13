using Inanna.LibraryContext.Application.Features.Mangas.Projections;
using Inanna.LibraryContext.Application.Features.Mangas.Projections.Repositories;

namespace Inanna.LibraryContext.Infrastructure.DataAccess.Mangas.Projections.Repositories;

public class GenreProjectionsRepository(MangasProjectionsDbContext dbContext) :
    DefaultProjectionsRepository<GenreProjection>(dbContext), IGenreProjectionsRepository;