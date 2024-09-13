using Inanna.LibraryContext.Application.Features.Mangas.Projections;
using Inanna.LibraryContext.Application.Features.Mangas.Projections.Repositories;

namespace Inanna.LibraryContext.Infrastructure.DataAccess.Mangas.Projections.Repositories;

public class GenreToMangaProjectionsRepository(MangasProjectionsDbContext dbContext) :
    DefaultProjectionsRepository<GenreToMangaProjection>(dbContext), IGenreToMangaProjectionsRepository;