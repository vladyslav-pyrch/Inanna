using Inanna.LibraryContext.Infrastructure.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inanna.LibraryContext.Infrastructure.DataAccess.Configurations;

public class GenreModelConfiguration : IEntityTypeConfiguration<GenreModel>
{
    public void Configure(EntityTypeBuilder<GenreModel> builder)
    {
        builder.HasKey(model => model.Name);

        builder.Property(model => model.Name)
            .IsRequired()
            .HasMaxLength(20);

        builder.HasMany(model => model.Mangas)
            .WithMany(model => model.Genres);
    }
}