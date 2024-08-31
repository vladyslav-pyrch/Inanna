using System.Reflection;
using Inanna.LibraryContext.Infrastructure.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace Inanna.LibraryContext.Infrastructure.DataAccess;

public class LibraryDbContext(DbContextOptions<LibraryDbContext> dbContextOptions) : DbContext(dbContextOptions)
{
    public DbSet<ChapterModel> Chapters { get; set; }

    public DbSet<VolumeModel> Volumes { get; set; }
        
    public DbSet<MangaModel> Mangas { get; set; }
        
    public DbSet<GenreModel> Genres { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(GetType())!);
    }
}