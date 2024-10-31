using Inanna.Core.Messaging;
using Inanna.LibraryContext.Domain.Model.Mangas;

namespace Inanna.LibraryContext.Application.Features.Mangas.Commands.Delete;

public record RemovePageCommand(Guid MangaId, Guid VolumeId, Guid ChapterId, int PageNumber) : ICommand;