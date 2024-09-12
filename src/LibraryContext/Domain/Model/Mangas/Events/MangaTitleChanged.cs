using Inanna.Core.Domain.Model;

namespace Inanna.LibraryContext.Domain.Model.Mangas.Events;

public record MangaTitleChanged(string Title) : DomainEvent<MangaId>;