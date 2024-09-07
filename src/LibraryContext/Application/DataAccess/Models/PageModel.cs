namespace Inanna.LibraryContext.Infrastructure.DataAccess.Models;

internal class PageModel
{
    public int Id { get; set; }
    
    public int Number { get; set; }
    
    public ImageModel Image { get; set; }
    
    public ChapterModel? Chapter { get; set; }
    
    public int? ChapterId { get; set; }
}