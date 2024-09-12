using Grpc.Core;
using Inanna.LibraryContext.Application.Features.Mangas.Commands.Create;
using Inanna.LibraryContext.Domain.Model.Mangas;
using MediatR;

namespace Inanna.LibraryContext.Api.Services;

public class MangaService(ISender sender) : Api.MangaService.MangaServiceBase
{
    public override async Task<CreateMangaResponse> CreateManga(CreateMangaRequest request, ServerCallContext context)
    {
        MangaId mangaId = await sender.Send(new CreateMangaCommand(
            request.Title,
            Enum.Parse<Domain.Model.Mangas.State>(request.State.ToString()),
            request.CoverBytes?.ToByteArray(),
            request.CoverContentType,
            request.Genres.ToList()
        ), context.CancellationToken);

        return new CreateMangaResponse { MangaId = mangaId.Value.ToString() };
    }
}