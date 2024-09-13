using Inanna.LibraryContext.Application.Features.Mangas.Projections;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inanna.LibraryContext.Infrastructure.DataAccess.Mangas.Projections.Configurations;

public class VolumeProjectionsConfiguration : IEntityTypeConfiguration<VolumeProjection>
{
    public void Configure(EntityTypeBuilder<VolumeProjection> builder)
    {
        builder.HasKey(projection => projection.Id);

        builder.Property(projection => projection.Id)
            .ValueGeneratedNever();

        builder.Property(projection => projection.Title)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(projection => projection.Number)
            .IsRequired();

        builder.HasOne<MangaProjection>()
            .WithMany()
            .HasForeignKey(projection => projection.MangaId)
            .OnDelete(DeleteBehavior.ClientCascade)
            .IsRequired();

        builder.HasMany<ChapterProjection>()
            .WithOne()
            .HasForeignKey(projection => projection.VolumeId)
            .OnDelete(DeleteBehavior.ClientCascade)
            .IsRequired();
    }
}