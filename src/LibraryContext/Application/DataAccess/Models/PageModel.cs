namespace Inanna.LibraryContext.Application.DataAccess.Models;

internal class PageModel
{
    public int Id { get; set; }
    
    public int Number { get; set; }
    
    public ImageModel Image { get; set; }
    
    public int? ChapterId { get; set; }
}