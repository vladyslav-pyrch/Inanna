using Inanna.Core.Messaging;

namespace Inanna.LibraryContext.Application.Features.Mangas.Commands.Update;

public record UpdateChapterCommand(
    Guid MangaId,
    Guid VolumeId,
    Guid ChapterId,
    string? Title,
    string? Number
    ) : ICommand;