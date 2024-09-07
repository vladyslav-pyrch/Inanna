using Inanna.LibraryContext.Domain.Model.Mangas;
using MediatR;

namespace Inanna.LibraryContext.Application.Features.Mangas.Queries.Get;

public record GetMangaByIdQuery(MangaId MangaId) : IRequest<Manga>;