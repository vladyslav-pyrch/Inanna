using System.Diagnostics.CodeAnalysis;
using Inanna.LibraryContext.Domain.Model.Mangas;
using MediatR;

namespace Inanna.LibraryContext.Application.Features.Mangas.Commands.Create;

public record CreateMangaCommand(
    string Title,
    State State,
    int PublisherId,
    [NotNullIfNotNull("CoverImageContentType")]byte[]? CoverImageBytes = null,
    [NotNullIfNotNull("CoverImageBytes")]string? CoverImageContentType = null,
    List<string>? Genres = null)
    : IRequest<MangaId>;