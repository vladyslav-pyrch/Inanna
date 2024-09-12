using Inanna.LibraryContext.Application.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inanna.LibraryContext.Application.DataAccess.Configurations;

internal class MangaModelConfiguration : IEntityTypeConfiguration<MangaModel>
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

        builder.HasMany<VolumeModel>()
            .WithOne()
            .HasForeignKey(model => model.MangaId)
            .OnDelete(DeleteBehavior.ClientCascade);

        builder.HasMany<GenreModel>()
            .WithMany()
            .UsingEntity<GenreToMangaModel>();

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