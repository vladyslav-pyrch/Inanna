using Inanna.Core.Domain.Model;

namespace Inanna.LibraryContext.Domain.Model.Mangas.Events;

public record VolumeTitleChanged(VolumeId VolumeId, string Title) : Event<MangaId>;