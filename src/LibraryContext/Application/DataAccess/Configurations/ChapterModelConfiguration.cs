using Inanna.LibraryContext.Application.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inanna.LibraryContext.Application.DataAccess.Configurations;

internal class ChapterModelConfiguration : IEntityTypeConfiguration<ChapterModel>
{
    public void Configure(EntityTypeBuilder<ChapterModel> builder)
    {
        builder.HasKey(model => model.Id);

        builder.Property(model => model.Title)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(model => model.Number)
            .IsRequired();

        builder.HasOne<VolumeModel>()
            .WithMany()
            .HasForeignKey(model => model.VolumeId)
            .OnDelete(DeleteBehavior.ClientCascade);

        builder.HasMany<PageModel>()
            .WithOne()
            .HasForeignKey(model => model.ChapterId)
            .OnDelete(DeleteBehavior.ClientCascade);
    }
}