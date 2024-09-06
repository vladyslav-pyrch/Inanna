using System.Diagnostics.CodeAnalysis;
using Inanna.LibraryContext.Application.DataAccess;
using Inanna.LibraryContext.Domain.Model.Mangas;
using Inanna.LibraryContext.Domain.Model.Shared;
using Inanna.LibraryContext.Infrastructure.DataAccess.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Inanna.LibraryContext.Application.Features.Mangas.Commands.Create;

public class CreateMangaCommandHandler(LibraryDbContext dbContext, IImageFileService imageFileService) 
    : IRequestHandler<CreateMangaCommand, MangaId>
{
    public async Task<MangaId> Handle(CreateMangaCommand request, CancellationToken cancellationToken)
    {
        var publisher = new Publisher(request.PublisherId);
        List<Genre> genres = request.Genres?.Select(genre => new Genre(genre)).ToList() ?? [];
        Image? cover = await SaveImageIfPossible(request.CoverImageBytes, request.CoverImageContentType);
        try
        {
            return await AddNewMangaToDb(new Manga(
                new MangaId(default),
                request.Title,
                request.State,
                publisher,
                cover,
                genres,
                []
            ));
        }
        finally
        {
            if (cover is not null)
                await imageFileService.DeleteImage(cover);
        }
    }

    private async Task<Image?> SaveImageIfPossible(
        [NotNullIfNotNull("coverImageContentType")]byte[]? coverImageBytes,
        [NotNullIfNotNull("coverImageBytes")]string? coverImageContentType)
    {
        if (coverImageContentType is null || coverImageBytes is null)
            return null;

        return await imageFileService.SaveImage(coverImageBytes, coverImageContentType);
    }

    private async Task<MangaId> AddNewMangaToDb(Manga manga)
    {
        var mangaModel = new MangaModel
        {
            Title = manga.Title,
            State = manga.State.ToString(),
            PublisherId = manga.Publisher.Id,
            Cover = manga.Cover is not null ? new ImageModel
                {
                    Path = manga.Cover.Path, ContentType = manga.Cover.ContentType
                } : null
        };
        await dbContext.Mangas.AddAsync(mangaModel);
        
        foreach (Genre genre in manga.Genres)
        {
            GenreModel? genreModel = await dbContext.Genres.Include(model => model.Mangas)
                .FirstOrDefaultAsync(model => model.Name == genre.Name);
            
            if (genreModel is null)
            {
                genreModel = new GenreModel { Name = genre.Name, Mangas = [] };
                await dbContext.AddAsync(genreModel);
            }
            
            genreModel.Mangas.Add(mangaModel);
        }

        await dbContext.SaveChangesAsync();

        return new MangaId(mangaModel.Id);
    }
}