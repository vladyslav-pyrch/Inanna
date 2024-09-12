using Inanna.LibraryContext.Application.DataAccess.Models;
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

        builder.HasOne<MangaModel>()
            .WithMany()
            .HasForeignKey(model => model.MangaId)
            .OnDelete(DeleteBehavior.ClientCascade);

        builder.HasMany<ChapterModel>()
            .WithOne()
            .HasForeignKey(model => model.VolumeId)
            .OnDelete(DeleteBehavior.ClientCascade);
    }
}