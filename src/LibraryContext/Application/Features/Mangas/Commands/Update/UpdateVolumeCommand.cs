using Inanna.Core.Messaging;
using Inanna.LibraryContext.Domain.Model.Mangas;

public record UpdateVolumeCommand(Guid MangaId, Guid VolumeId, string? Title, string? Number) : ICommand;