using Inanna.LibraryContext.Domain.Model.Shared;

namespace Inanna.LibraryContext.Domain.Model.Mangas.Volumes.Chapters;

public record ChapterId(int Value) : IntegerIdentity(Value);