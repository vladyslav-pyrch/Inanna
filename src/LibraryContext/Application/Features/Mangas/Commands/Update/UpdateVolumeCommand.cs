using Inanna.Core.Messaging;
using Inanna.LibraryContext.Domain.Model.Mangas;

public record UpdateVolumeCommand(MangaId MangaId, VolumeId VolumeId, string? Title, string? Number) : ICommand;