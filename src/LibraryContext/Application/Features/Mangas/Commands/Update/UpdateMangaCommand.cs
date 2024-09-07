using Inanna.LibraryContext.Domain.Model.Mangas;
using MediatR;

namespace Inanna.LibraryContext.Application.Features.Mangas.Commands.Update;

public record UpdateMangaCommand(Manga Manga) : IRequest;