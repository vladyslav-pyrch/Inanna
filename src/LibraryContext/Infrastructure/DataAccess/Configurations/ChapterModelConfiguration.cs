using Inanna.LibraryContext.Infrastructure.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inanna.LibraryContext.Infrastructure.DataAccess.Configurations;

public class ChapterModelConfiguration : IEntityTypeConfiguration<ChapterModel>
{
    public void Configure(EntityTypeBuilder<ChapterModel> builder)
    {
        builder.HasKey(model => model.Id);

        builder.Property(model => model.Title)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(model => model.Number)
            .IsRequired();

        builder.HasOne(model => model.Volume)
            .WithMany(model => model.Chapters)
            .HasForeignKey(model => model.VolumeId)
            .IsRequired();

        builder.OwnsMany(model => model.Pages, navigationBuilder =>
        {
            navigationBuilder.HasKey(model => model.Id);

            navigationBuilder.Property(model => model.Number)
                .IsRequired();

            navigationBuilder.OwnsOne(model => model.Image, navigationBuilder2 =>
            {
                navigationBuilder2.Property(model => model.Path)
                    .IsRequired();
                navigationBuilder2.Property(model => model.ContentType)
                    .IsRequired();
                navigationBuilder2.WithOwner();
            });
            
            navigationBuilder.WithOwner(model => model.Chapter)
                .HasForeignKey(model => model.ChapterId);
        });
    }
}