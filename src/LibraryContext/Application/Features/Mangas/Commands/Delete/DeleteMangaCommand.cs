using Inanna.Core.Messaging;

namespace Inanna.LibraryContext.Application.Features.Mangas.Commands.Delete;

public record DeleteMangaCommand(Guid MangaId) : ICommand;