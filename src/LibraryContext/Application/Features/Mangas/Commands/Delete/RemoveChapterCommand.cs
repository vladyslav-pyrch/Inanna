using Inanna.Core.Messaging;
using Inanna.LibraryContext.Domain.Model.Mangas;

namespace Inanna.LibraryContext.Application.Features.Mangas.Commands.Delete;

public record RemoveChapterCommand(MangaId MangaId, VolumeId VolumeId, ChapterId ChapterId) : ICommand;