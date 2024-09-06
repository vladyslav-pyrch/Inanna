using Inanna.LibraryContext.Infrastructure.DataAccess.Models;
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

        builder.HasMany(model => model.Mangas)
            .WithMany(model => model.Genres);
    }
}