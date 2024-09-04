using Inanna.LibraryContext.Domain.Model.Mangas;
using MediatR;

namespace Inanna.LibraryContext.Application.Features.Mangas.Commands.Create;

public record CreateMangaCommand(
    string Title,
    State State,
    int PublisherId,
    byte[]? CoverImageBytes = null,
    string? CoverImageContentType = null,
    List<string>? Genres = null)
    : IRequest<MangaId>;