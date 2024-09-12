using Inanna.Core.Domain.Model;

namespace Inanna.LibraryContext.Domain.Model.Mangas.Events;

public record MangaStateChanged(State State) : DomainEvent<MangaId>;