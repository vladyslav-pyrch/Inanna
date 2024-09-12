using Inanna.LibraryContext.Application.Features.Mangas.Projections;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inanna.LibraryContext.Infrastructure.DataAccess.Mangas.Projections.Configurations;

public class PageProjectionsConfiguration : IEntityTypeConfiguration<PageProjection>
{
    public void Configure(EntityTypeBuilder<PageProjection> builder)
    {
        builder.HasKey(projection => projection.Id);

        builder.Property(projection => projection.Id)
            .ValueGeneratedNever();

        builder.Property(projection => projection.Number)
            .IsRequired();

        builder.OwnsOne(projection => projection.Image, navigationBuilder2 =>
        {
            navigationBuilder2.Property(projection => projection.Path)
                .IsRequired();
            navigationBuilder2.Property(projection => projection.ContentType)
                .IsRequired();
            navigationBuilder2.WithOwner();
        });

        builder.HasOne<ChapterProjection>()
            .WithMany()
            .HasForeignKey(projection => projection.ChapterId)
            .OnDelete(DeleteBehavior.ClientCascade);
    }
}