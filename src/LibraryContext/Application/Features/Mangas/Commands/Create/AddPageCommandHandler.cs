using Inanna.Core.Messaging;
using Inanna.LibraryContext.Application.Features.Mangas.Queries.Get;
using Inanna.LibraryContext.Domain.Model.Mangas;
using Inanna.LibraryContext.Domain.Model.Shared;
using MediatR;

namespace Inanna.LibraryContext.Application.Features.Mangas.Commands.Create;

public class AddPageCommandHandler(IMangaRepository mangaRepository, IPublisher publisher, ISender sender, IFileService fileService)
    : ICommandHandler<AddPageCommand>
{
    public async Task Handle(AddPageCommand request, CancellationToken cancellationToken)
    {
        var mangaId = new MangaId(request.MangaId);
        var volumeId = new VolumeId(request.VolumeId);
        var chapterId = new ChapterId(request.ChapterId);
        
        Manga manga = await mangaRepository.GetById(mangaId, cancellationToken);

        string path = await fileService.Save(request.ImageBytes, request.ImageContentType);
        
        manga.AddPage(volumeId, chapterId, request.PageNumber, path, request.ImageContentType);

        await manga.PublishEvents(publisher);
    }
}