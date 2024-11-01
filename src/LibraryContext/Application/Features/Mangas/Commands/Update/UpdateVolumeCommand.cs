using Inanna.Core.Messaging;
using Inanna.LibraryContext.Domain.Model.Mangas;

namespace Inanna.LibraryContext.Application.Features.Mangas.Commands.Update;

public record UpdateVolumeCommand(Guid MangaId, Guid VolumeId, string? Title, string? Number) : ICommand;