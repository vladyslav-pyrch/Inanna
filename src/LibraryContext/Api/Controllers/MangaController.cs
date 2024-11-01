using Inanna.LibraryContext.Api.Dtos;
using Inanna.LibraryContext.Application.Features.Mangas.Commands.Create;
using Inanna.LibraryContext.Domain;
using Inanna.LibraryContext.Domain.Model.Mangas;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Inanna.LibraryContext.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class MangaController(ISender sender) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateManga([FromForm] CreateMangaDto createMangaDto)
    {
        if (!MyRegexes.Trimmed().IsMatch(createMangaDto.Title))
            ModelState.AddModelError("Title", "Title should be trimmed");
        if (createMangaDto.Genres != null && createMangaDto.Genres.Any(genre => !MyRegexes.Trimmed().IsMatch(genre)))
            ModelState.AddModelError("Genres", "All genres should be trimmed");
        if (createMangaDto.Genres != null && createMangaDto.Genres.Any(genre => genre.Length > 20))
            ModelState.AddModelError("Genres", "All genres should be not be longer than 20 character");
        if (createMangaDto.Genres != null && createMangaDto.Genres.Any(string.IsNullOrWhiteSpace))
            ModelState.AddModelError("Genres", "All genres should be not null or empty");

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        byte[]? imageBytes = null;
        string? imageContentType = null;

        if (createMangaDto.CoverImage is not null)
        {
            imageContentType = createMangaDto.CoverImage.ContentType;

            using var memoryStream = new MemoryStream();
            await createMangaDto.CoverImage.CopyToAsync(memoryStream);
            
            imageBytes = memoryStream.ToArray();
        }


        MangaId mangaId = await sender.Send(new CreateMangaCommand(
            createMangaDto.Title,
            createMangaDto.State,
            imageBytes,
            imageContentType,
            createMangaDto.Genres)
        );

        string url = Url.Action("GetById", new { id = mangaId.Value });

        return Created(url, new { id = mangaId.Value });
    }
}