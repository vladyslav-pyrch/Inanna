using Inanna.LibraryContext.Application.DataAccess;
using Inanna.LibraryContext.Domain.Model.Mangas;
using Inanna.LibraryContext.Domain.Model.Mangas.Volumes;
using Inanna.LibraryContext.Infrastructure.DataAccess.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Inanna.LibraryContext.Application.Features.Mangas.Commands.Update;

public class UpdateMangaCommandHandler(LibraryDbContext dbContext) : IRequestHandler<UpdateMangaCommand>
{
    public async Task Handle(UpdateMangaCommand request, CancellationToken cancellationToken)
    {
        //TODO: NOT WORKING
        var mangaModel = new MangaModel
        {
            Id = request.Manga.Identity.Value,
            Title = request.Manga.Title,
            State = request.Manga.State.ToString(),
            PublisherId = request.Manga.Publisher.Id,
            Cover = request.Manga.Cover is null ? null : new ImageModel
            {
                Path = request.Manga.Cover.Path,
                ContentType = request.Manga.Cover.ContentType
            },
            Genres = request.Manga.Genres
                .Select(genre => dbContext.Genres.First(model => model.Name == genre.Name))
                .ToList(),
            Volumes = request.Manga.Volumes
                .Select(volumeId => dbContext.Volumes.First(model => model.Id == volumeId.Value))
                .ToList()
        };
        
        dbContext.Update(mangaModel);
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}