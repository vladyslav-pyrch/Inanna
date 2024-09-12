using System.Diagnostics.CodeAnalysis;
using Inanna.Core.Messaging;
using Inanna.LibraryContext.Domain.Model.Mangas;

namespace Inanna.LibraryContext.Application.Features.Mangas.Commands.Create;

public record CreateMangaCommand(
    string Title,
    State State,
    [NotNullIfNotNull("CoverImageContentType")]byte[]? CoverImageBytes = null,
    [NotNullIfNotNull("CoverImageBytes")]string? CoverImageContentType = null,
    List<string>? Genres = null)
    : ICommand<MangaId>;