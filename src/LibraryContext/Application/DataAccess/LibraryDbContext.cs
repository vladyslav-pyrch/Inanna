using System.Reflection;
using Inanna.LibraryContext.Application.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace Inanna.LibraryContext.Application.DataAccess;

public class LibraryDbContext(DbContextOptions<LibraryDbContext> dbContextOptions) : DbContext(dbContextOptions)
{
    internal DbSet<ChapterModel> Chapters { get; set; }

    internal DbSet<VolumeModel> Volumes { get; set; }
        
    internal DbSet<MangaModel> Mangas { get; set; }
        
    internal DbSet<GenreModel> Genres { get; set; }
    
    internal DbSet<GenreToMangaModel> GenresToMangas { get; set; }
    
    internal DbSet<PageModel> Pages { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(GetType())!);
    }
}