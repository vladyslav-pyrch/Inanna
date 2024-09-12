using Inanna.Core.Domain.Model;

namespace Inanna.LibraryContext.Domain.Model.Mangas.Events;

public record VolumeRemoved(VolumeId VolumeId) : DomainEvent<MangaId>;