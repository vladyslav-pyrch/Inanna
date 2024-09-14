using Inanna.Core.Domain.Model;

namespace Inanna.LibraryContext.Domain.Model.Mangas.Events;

public record ChapterTitleChanged(VolumeId VolumeId, ChapterId ChapterId, string Title) : Event<MangaId>;