using Inanna.Core.Messaging;
using Inanna.LibraryContext.Domain.Model.Mangas;

namespace Inanna.LibraryContext.Application.Features.Mangas.Commands.Create;

public record AddVolumeCommand(MangaId MangaId, string Title, string Number) : ICommand<VolumeId>;