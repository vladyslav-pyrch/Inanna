using Inanna.Core.Messaging;
using Inanna.LibraryContext.Application.Features.Mangas.Projections;

namespace Inanna.LibraryContext.Application.Features.Mangas.Queries.List;

public record ListMangasQuery : IQuery<List<MangaProjection>>;