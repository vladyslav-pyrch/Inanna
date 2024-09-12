using System.Reflection;
using Inanna.LibraryContext.Application.Features.Mangas.Projections;
using Microsoft.EntityFrameworkCore;

namespace Inanna.LibraryContext.Infrastructure.DataAccess.Mangas.Projections;

public class MangasProjectionsDbContext(DbContextOptions<MangasProjectionsDbContext> dbContextOptions) : DbContext(dbContextOptions)
{
    public DbSet<ChapterProjection> Chapters { get; set; }

    public DbSet<VolumeProjection> Volumes { get; set; }
        
    public DbSet<MangaProjection> Mangas { get; set; }
        
    public DbSet<GenreProjection> Genres { get; set; }
    
    public DbSet<GenreToMangaProjection> GenresToMangas { get; set; }
    
    public DbSet<PageProjection> Pages { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(GetType())!);
    }
}