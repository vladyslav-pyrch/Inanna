using Inanna.Core.Domain.Model;

namespace Inanna.LibraryContext.Domain.Model.Mangas.Events;

public record MangaDeleted(MangaId MangaId) : Event<MangaId>;