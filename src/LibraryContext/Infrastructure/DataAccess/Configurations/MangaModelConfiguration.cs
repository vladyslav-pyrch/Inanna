using Inanna.LibraryContext.Infrastructure.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inanna.LibraryContext.Infrastructure.DataAccess.Configurations;

public class MangaModelConfiguration : IEntityTypeConfiguration<MangaModel>
{
    public void Configure(EntityTypeBuilder<MangaModel> builder)
    {
        builder.HasKey(model => model.Id);

        builder.Property(model => model.Title)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(model => model.State)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(model => model.PublisherId)
            .IsRequired();

        builder.OwnsMany(model => model.Genres, navigationBuilder =>
        {
            navigationBuilder.Property(model => model.Name)
                .IsRequired()
                .HasMaxLength(20);
            navigationBuilder.WithOwner();
        });

        builder.HasMany(model => model.Volumes)
            .WithOne(model => model.Manga)
            .HasForeignKey(model => model.MangaId)
            .IsRequired();

        builder.OwnsOne(model => model.Cover, navigationBuilder =>
        {
            navigationBuilder.Property(model => model.Path)
                .IsRequired();
            navigationBuilder.Property(model => model.ContentType)
                .IsRequired();
            navigationBuilder.WithOwner();
        });
    }
}