using Inanna.Core.Domain.Model;

namespace Inanna.LibraryContext.Domain.Model.Mangas.Volumes.Chapters;

public record ChapterId(int Value) : Identity<int>(Value);