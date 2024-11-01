using Inanna.Core.Messaging;

namespace Inanna.LibraryContext.Application.Features.Mangas.Queries.Get;

public class ChapterExistsQueryHandler(MangasProjectionsUnitOfWork unitOfWork) : IQueryHandler<ChapterExistsQuery, bool>
{
    public Task<bool> Handle(ChapterExistsQuery request, CancellationToken cancellationToken)
    {
        bool exists = unitOfWork.ChapterProjections.Query().Any(projection => projection.Id == request.ChapterId);
        
        return Task.FromResult(exists);
    }
}