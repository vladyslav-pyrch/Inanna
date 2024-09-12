using Inanna.LibraryContext.Domain.Model.Shared;

namespace Inanna.LibraryContext.Domain.Model.Mangas;

public record MangaId(Guid Value) : GuidAbstractIdentity(Value);