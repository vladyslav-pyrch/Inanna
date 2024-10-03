using System.Diagnostics.CodeAnalysis;
using Inanna.Core.Messaging;

namespace Inanna.LibraryContext.Application.Features.Mangas.Commands.Update;

public record UpdateMangaCommand(
    Guid MangaId, 
    string? Title,
    string? State,
    [NotNullIfNotNull("CoverImageContentType")]byte[]? CoverImageBytes = null,
    [NotNullIfNotNull("CoverImageBytes")]string? CoverImageContentType = null
    ) : ICommand;