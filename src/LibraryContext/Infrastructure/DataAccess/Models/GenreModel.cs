namespace Inanna.LibraryContext.Infrastructure.DataAccess.Models;

public class GenreModel
{
    public string Name { get; set; }
    
    public IEnumerable<MangaModel> Mangas { get; set; }
}