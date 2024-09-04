using Inanna.LibraryContext.Domain.Model.Mangas;
using Inanna.LibraryContext.Domain.Model.Shared;
using MediatR;

namespace Inanna.LibraryContext.Application.Features.Mangas.Commands.Create;

public class CreateMangaCommandHandler(IMangaRepository mangaRepository, IImageFileService imageFileService)
    : IRequestHandler<CreateMangaCommand, MangaId>
{
    public async Task<MangaId> Handle(CreateMangaCommand request, CancellationToken cancellationToken)
    {
        MangaId id;
        Image? cover = null;

        if (request is { CoverImageBytes: not null, CoverImageContentType: not null })
            cover = await imageFileService.SaveImage(request.CoverImageBytes, request.CoverImageContentType);

        try
        {
            var manga = new Manga(
                new MangaId(default),
                request.Title,
                request.State,
                new Publisher(request.PublisherId),
                cover,
                request.Genres?.Select(genreName => new Genre(genreName)).ToList() ?? [],
                []
            );

            id = await mangaRepository.Add(manga);
            await mangaRepository.SaveChanges(cancellationToken);
        }
        catch
        {
            if (cover is not null)
                await imageFileService.DeleteImage(cover);
            throw;
        }

        return id;
    }
}