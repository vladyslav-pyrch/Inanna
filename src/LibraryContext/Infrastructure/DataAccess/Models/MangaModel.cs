namespace Inanna.LibraryContext.Infrastructure.DataAccess.Models;

public class MangaModel
{
    public int Id { get; set; }
    
    public string Title { get; set; }
    
    public ImageModel Cover { get; set; }
    
    public int PublisherId { get; set; }

    public IEnumerable<GenreModel> Genres { get; set; }
    
    public IEnumerable<VolumeModel> Volumes { get; set; }
}