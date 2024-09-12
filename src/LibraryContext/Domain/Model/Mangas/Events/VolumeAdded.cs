using Inanna.Core.Domain.Model;

namespace Inanna.LibraryContext.Domain.Model.Mangas.Events;

public record VolumeAdded(VolumeId VolumeId, string Title, string Number) : DomainEvent<MangaId>;