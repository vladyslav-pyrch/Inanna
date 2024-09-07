using Inanna.LibraryContext.Application.DataAccess;
using Inanna.LibraryContext.Application.Features.Mangas.Commands.Update;
using Inanna.LibraryContext.Application.Features.Mangas.Queries.Get;
using Inanna.LibraryContext.Domain.Model.Mangas;
using Inanna.LibraryContext.Domain.Model.Mangas.Volumes;
using Inanna.LibraryContext.Infrastructure.DataAccess.Models;
using MediatR;

namespace Inanna.LibraryContext.Application.Features.Mangas.Commands.Create;

public class AddNewVolumeCommandHandler(LibraryDbContext dbContext, ISender sender) : IRequestHandler<AddNewVolumeCommand, VolumeId>
{
    public async Task<VolumeId> Handle(AddNewVolumeCommand request, CancellationToken cancellationToken)
    {
        var volume = new Volume(
            new VolumeId(default),
            request.Title,
            request.Number,
            []
        );

        VolumeId volumeId = await AddNewVolumeToDb(volume, cancellationToken);
        Manga manga = await sender.Send(new GetMangaByIdQuery(new MangaId(request.MangaId)), cancellationToken);
        
        manga.AddVolume(volumeId);
        
        await sender.Send(new UpdateMangaCommand(manga), cancellationToken);
        
        return volumeId;
    }

    private async Task<VolumeId> AddNewVolumeToDb(Volume volume, CancellationToken cancellationToken)
    {
        var volumeModel = new VolumeModel
        {
            Title = volume.Title,
            Number = volume.Number
        };

        await dbContext.Volumes.AddAsync(volumeModel, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new VolumeId(volumeModel.Id);
    }
}