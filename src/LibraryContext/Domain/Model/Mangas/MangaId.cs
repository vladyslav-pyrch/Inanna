using Inanna.LibraryContext.Domain.Model.Shared;

namespace Inanna.LibraryContext.Domain.Model.Mangas;

public record MangaId(int Value) : IntegerIdentity(Value);