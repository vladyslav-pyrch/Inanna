using Inanna.Core.Messaging;

namespace Inanna.LibraryContext.Application.Features.Mangas.Commands.Delete;

public record RemoveGenreCommand(Guid MangaId, string Genre) : ICommand;