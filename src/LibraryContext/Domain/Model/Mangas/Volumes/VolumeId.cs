using Inanna.LibraryContext.Domain.Model.Shared;

namespace Inanna.LibraryContext.Domain.Model.Mangas.Volumes;

public record VolumeId(int Value) : IntegerIdentity(Value);