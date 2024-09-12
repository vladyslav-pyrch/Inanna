using Inanna.LibraryContext.Domain.Model.Shared;

namespace Inanna.LibraryContext.Domain.Model.Mangas;

public record ChapterId(Guid Value) : GuidAbstractIdentity(Value);