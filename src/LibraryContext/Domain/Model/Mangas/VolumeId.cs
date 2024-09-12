using Inanna.LibraryContext.Domain.Model.Shared;

namespace Inanna.LibraryContext.Domain.Model.Mangas;

public record VolumeId(Guid Value) : GuidAbstractIdentity(Value);