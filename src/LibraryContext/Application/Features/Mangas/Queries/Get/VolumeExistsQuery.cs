using Inanna.Core.Messaging;

namespace Inanna.LibraryContext.Application.Features.Mangas.Queries.Get;

public record VolumeExistsQuery(Guid VolumeId) : IQuery<bool>;