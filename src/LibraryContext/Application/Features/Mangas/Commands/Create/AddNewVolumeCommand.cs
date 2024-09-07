using Inanna.LibraryContext.Domain.Model.Mangas;
using Inanna.LibraryContext.Domain.Model.Mangas.Volumes;
using MediatR;

namespace Inanna.LibraryContext.Application.Features.Mangas.Commands.Create;

public record AddNewVolumeCommand(int MangaId, string Title, string Number) : IRequest<VolumeId>;