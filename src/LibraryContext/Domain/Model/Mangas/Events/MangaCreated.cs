using Inanna.Core.Domain.Model;

namespace Inanna.LibraryContext.Domain.Model.Mangas.Events;

public record MangaCreated(MangaId MangaId, string Title, State State) : Event<MangaId>;