namespace Inanna.LibraryContext.Infrastructure.DataAccess.Models;

internal class GenreModel
{
    public string Name { get; set; }
    
    public ICollection<MangaModel> Mangas { get; set; }
}