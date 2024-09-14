using Inanna.Core.Domain.Model;

namespace Inanna.LibraryContext.Domain.Model.Mangas.Events;

public record ChapterNumberChanged(VolumeId VolumeId, ChapterId ChapterId, string Number) : Event<MangaId>;