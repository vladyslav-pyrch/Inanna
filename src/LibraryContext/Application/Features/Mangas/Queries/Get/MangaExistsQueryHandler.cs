using Inanna.Core.Messaging;

namespace Inanna.LibraryContext.Application.Features.Mangas.Queries.Get;

public class MangaExistsQueryHandler(MangasProjectionsUnitOfWork unitOfWork) : IQueryHandler<MangaExistsQuery, bool>
{
    public Task<bool> Handle(MangaExistsQuery request, CancellationToken cancellationToken)
    {
        bool exists = unitOfWork.MangaProjections.Query().Any(projection => projection.Id == request.MangaId);

        return Task.FromResult(exists);
    }
}