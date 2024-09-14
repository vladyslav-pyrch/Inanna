using Inanna.Core.Domain.Model;

namespace Inanna.LibraryContext.Domain.Model.Mangas.Events;

public record VolumeNumberChanged(VolumeId VolumeId, string Number) : Event<MangaId>;