﻿using Inanna.Core.Messaging;
using Inanna.LibraryContext.Domain.Model.Mangas;
using Inanna.LibraryContext.Domain.Model.Shared;
using MediatR;

namespace Inanna.LibraryContext.Application.Features.Mangas.Commands.Update;

public class UpdateMangaCommandHandler(IMangaRepository mangaRepository, IPublisher publisher, IFileService fileService)
    : ICommandHandler<UpdateMangaCommand>
{
    public async Task Handle(UpdateMangaCommand request, CancellationToken cancellationToken)
    {
        var mangaId = new MangaId(request.MangaId);
        Manga manga = await mangaRepository.GetById(mangaId, cancellationToken);

        if (request is { State: not null })
            manga.ChangeState(Enum.Parse<State>(request.State));
        
        if (request is { Title:not null })
            manga.ChangeTitle(request.Title);
        
        if (request is { CoverImageBytes: not null, CoverImageContentType: not null})
        {
            string path = await fileService.Save(request.CoverImageBytes, request.CoverImageContentType);
            var image = new Image(path, request.CoverImageContentType);
            manga.ChangeCover(image);
        }

        await manga.PublishEvents(publisher);
    }
}