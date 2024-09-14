using Inanna.LibraryContext.Application.Features.Mangas.Projections;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inanna.LibraryContext.Infrastructure.DataAccess.Mangas.Projections.Configurations;

public class PageProjectionsConfiguration : IEntityTypeConfiguration<PageProjection>
{
    public void Configure(EntityTypeBuilder<PageProjection> builder)
    {
        builder.HasKey(projection => new { projection.Number, projection.ChapterId });

        builder.Property(projection => projection.Number)
            .IsRequired();

        builder.OwnsOne(projection => projection.Image, navigationBuilder =>
        {
            navigationBuilder.Property(projection => projection.Path)
                .IsRequired();
            navigationBuilder.Property(projection => projection.ContentType)
                .IsRequired();
            navigationBuilder.WithOwner();
        });

        builder.HasOne<ChapterProjection>()
            .WithMany()
            .HasForeignKey(projection => projection.ChapterId)
            .OnDelete(DeleteBehavior.ClientCascade)
            .IsRequired();
    }
}