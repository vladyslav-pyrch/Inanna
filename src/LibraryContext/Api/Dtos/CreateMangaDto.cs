using System.ComponentModel.DataAnnotations;
using Inanna.LibraryContext.Domain.Model.Mangas;

namespace Inanna.LibraryContext.Api.Dtos;

public class CreateMangaDto
{
    [Required]
    [StringLength(100, MinimumLength = 1)]
    public string Title { get; set; }
    
    [Required]
    [EnumDataType(typeof(State))]
    public string State { get; set; }
    
    [FileExtensions(Extensions = "jpg jpeg png")]
    public IFormFile? CoverImage { get; set; }
    
    public List<string>? Genres { get; set; } 
}