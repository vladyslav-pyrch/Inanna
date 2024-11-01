using Inanna.Core.Messaging;

namespace Inanna.LibraryContext.Application.Features.Mangas.Queries.Get;

public record MangaExistsQuery(Guid MangaId) : IQuery<bool>;