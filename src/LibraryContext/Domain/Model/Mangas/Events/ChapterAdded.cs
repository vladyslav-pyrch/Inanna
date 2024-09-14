using Inanna.Core.Domain.Model;

namespace Inanna.LibraryContext.Domain.Model.Mangas.Events;

public record ChapterAdded(VolumeId VolumeId, ChapterId ChapterId, string Title, string Number) : Event<MangaId>;