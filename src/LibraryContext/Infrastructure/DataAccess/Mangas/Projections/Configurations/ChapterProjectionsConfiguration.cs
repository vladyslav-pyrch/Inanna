using Inanna.LibraryContext.Application.Features.Mangas.Projections;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inanna.LibraryContext.Infrastructure.DataAccess.Mangas.Projections.Configurations;

public class ChapterProjectionsConfiguration : IEntityTypeConfiguration<ChapterProjection>
{
    public void Configure(EntityTypeBuilder<ChapterProjection> builder)
    {
        builder.HasKey(projection => projection.Id);

        builder.Property(projection => projection.Id)
            .ValueGeneratedNever();

        builder.Property(projection => projection.Title)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(projection => projection.Number)
            .IsRequired();

        builder.HasOne<VolumeProjection>()
            .WithMany()
            .HasForeignKey(projection => projection.VolumeId)
            .OnDelete(DeleteBehavior.ClientCascade);

        builder.HasMany<PageProjection>()
            .WithOne()
            .HasForeignKey(projection => projection.ChapterId)
            .OnDelete(DeleteBehavior.ClientCascade);
    }
}