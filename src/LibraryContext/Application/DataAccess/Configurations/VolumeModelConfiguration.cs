using Inanna.LibraryContext.Infrastructure.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inanna.LibraryContext.Application.DataAccess.Configurations;

internal class VolumeModelConfiguration : IEntityTypeConfiguration<VolumeModel>
{
    public void Configure(EntityTypeBuilder<VolumeModel> builder)
    {
        builder.HasKey(model => model.Id);

        builder.Property(model => model.Title)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(model => model.Number)
            .IsRequired();

        builder.HasOne(model => model.Manga)
            .WithMany(model => model.Volumes)
            .HasForeignKey(model => model.MangaId);

        builder.HasMany(model => model.Chapters)
            .WithOne(model => model.Volume)
            .HasForeignKey(model => model.VolumeId);
    }
}