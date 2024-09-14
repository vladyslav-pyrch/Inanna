using Inanna.Core.Domain.Model;

namespace Inanna.LibraryContext.Domain.Model.Mangas.Events;

public record ChapterRemoved(VolumeId VolumeId, ChapterId ChapterId) : Event<MangaId>;