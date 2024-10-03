using Inanna.Core.Messaging;
using Inanna.LibraryContext.Domain.Model.Mangas;

namespace Inanna.LibraryContext.Application.Features.Mangas.Commands.Create;

public record AddChapterCommand(Guid MangaId, Guid VolumeId, string Title, string Number) : ICommand<ChapterId>;