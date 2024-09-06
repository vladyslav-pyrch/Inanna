namespace Inanna.LibraryContext.Infrastructure.DataAccess.Models;

internal class MangaModel
{
    public int Id { get; set; }
    
    public string Title { get; set; }
    
    public string State { get; set; }
    
    public ImageModel? Cover { get; set; }
    
    public int PublisherId { get; set; }

    public ICollection<GenreModel> Genres { get; set; }
    
    public ICollection<VolumeModel> Volumes { get; set; }
}