using Inanna.Core.Messaging;
using Inanna.LibraryContext.Domain.Model.Mangas;
using Inanna.LibraryContext.Domain.Model.Shared;
using MediatR;

namespace Inanna.LibraryContext.Application.Features.Mangas.Commands.Delete;

public class RemovePageCommandHandler(IMangaRepository mangaRepository, IPublisher publisher, IFileService fileService)
    : ICommandHandler<RemovePageCommand>
{
    public async Task Handle(RemovePageCommand request, CancellationToken cancellationToken)
    {
        var mangaId = new MangaId(request.MangaId);
        var volumeId = new VolumeId(request.VolumeId);
        var chapterId = new ChapterId(request.ChapterId);
        int pageNumber = request.PageNumber;
        
        Manga manga = await mangaRepository.GetById(mangaId, cancellationToken);

        // Page page = manga.Volumes.Single(volume => volume.Identity == request.VolumeId)
        //     .Chapters.Single(chapter => chapter.Identity == request.ChapterId)
        //     .Pages.Single(page1 => page1.Number == request.PageNumber);
        //fileService.Delete(page.Image.Path)
        
        manga.RemovePage(volumeId, chapterId, pageNumber);

        await manga.PublishEvents(publisher);
    }
}