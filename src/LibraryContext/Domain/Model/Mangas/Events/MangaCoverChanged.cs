using Inanna.Core.Domain.Model;
using Inanna.LibraryContext.Domain.Model.Shared;

namespace Inanna.LibraryContext.Domain.Model.Mangas.Events;

public record MangaCoverChanged(Image Cover) : DomainEvent<MangaId>;