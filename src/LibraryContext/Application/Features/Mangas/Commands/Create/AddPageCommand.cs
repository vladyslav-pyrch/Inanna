using Inanna.Core.Messaging;
using Inanna.LibraryContext.Domain.Model.Mangas;

namespace Inanna.LibraryContext.Application.Features.Mangas.Commands.Create;

public record AddPageCommand(Guid MangaId, Guid VolumeId, Guid ChapterId,
    int PageNumber, byte[] ImageBytes, string ImageContentType) : ICommand;