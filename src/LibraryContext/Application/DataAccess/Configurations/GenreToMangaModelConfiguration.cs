using Inanna.LibraryContext.Application.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inanna.LibraryContext.Application.DataAccess.Configurations;

internal class GenreToMangaModelConfiguration : IEntityTypeConfiguration<GenreToMangaModel>
{
    public void Configure(EntityTypeBuilder<GenreToMangaModel> builder)
    {
        builder.HasKey(model => new { model.MangaId, model.GenreName });
        
        builder.HasOne<MangaModel>()
            .WithMany()
            .HasForeignKey(model => model.MangaId)
            .IsRequired()
            .OnDelete(DeleteBehavior.ClientCascade);
        
        builder.HasOne<GenreModel>()
            .WithMany()
            .HasForeignKey(model => model.GenreName)
            .IsRequired()
            .OnDelete(DeleteBehavior.ClientCascade);
    }
}