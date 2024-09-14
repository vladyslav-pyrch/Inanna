using Inanna.Core.Domain.Model;

namespace Inanna.LibraryContext.Domain.Model.Mangas.Events;

public record PageAdded(VolumeId VolumeId, ChapterId ChapterId, int PageNumber, string ImagePath, string ImageContentType)
    : Event<MangaId>;