using Inanna.Core.Domain.Model;

namespace Inanna.LibraryContext.Domain.Model.Mangas.Volumes;

public record VolumeId(int Value) : Identity<int>(Value);