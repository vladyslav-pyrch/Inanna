using Inanna.Core.Messaging;

namespace Inanna.LibraryContext.Application.Features.Mangas.Queries.Get;

public class VolumeExistsQueryHandler(MangasProjectionsUnitOfWork unitOfWork) : IQueryHandler<VolumeExistsQuery, bool>
{
    public Task<bool> Handle(VolumeExistsQuery request, CancellationToken cancellationToken)
    {
        bool result = unitOfWork.VolumeProjections.Query().Any(projection => projection.Id == request.VolumeId);
        
        return Task.FromResult(result);
    }
}