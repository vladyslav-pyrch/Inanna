using Inanna.Core.Messaging;

namespace Inanna.LibraryContext.Application.Features.Mangas.Commands.Delete;

public record RemoveVolumeCommand(Guid MangaId, Guid VolumeId) : ICommand;