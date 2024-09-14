using Inanna.Core.Domain.Model;

namespace Inanna.LibraryContext.Domain.Model.Mangas.Events;

public record PageRemoved(VolumeId VolumeId, ChapterId ChapterId, int PageNumber) : Event<MangaId>;