using Inanna.LibraryContext.Application.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inanna.LibraryContext.Application.DataAccess.Configurations;

internal class GenreModelConfiguration : IEntityTypeConfiguration<GenreModel>
{
    public void Configure(EntityTypeBuilder<GenreModel> builder)
    {
        builder.HasKey(model => model.Name);
        
        builder.Property(model => model.Name)
            .HasMaxLength(20)
            .IsRequired();

        builder.HasMany<MangaModel>()
            .WithMany()
            .UsingEntity<GenreToMangaModel>();

        builder.HasData(
            [
                new GenreModel { Name = "genre 1" },
                new GenreModel { Name = "genre 2" },
                new GenreModel { Name = "genre 3" },
                new GenreModel { Name = "genre 4" }
            ]
        );
    }
}