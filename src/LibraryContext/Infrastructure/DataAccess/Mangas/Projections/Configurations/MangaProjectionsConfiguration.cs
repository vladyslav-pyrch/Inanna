using Inanna.LibraryContext.Application.Features.Mangas.Projections;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inanna.LibraryContext.Infrastructure.DataAccess.Mangas.Projections.Configurations;

public class MangaProjectionsConfiguration : IEntityTypeConfiguration<MangaProjection>
{
    public void Configure(EntityTypeBuilder<MangaProjection> builder)
    {
        builder.HasKey(projection => projection.Id);

        builder.Property(projection => projection.Id)
            .ValueGeneratedNever();

        builder.Property(projection => projection.Title)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(projection => projection.State)
            .HasMaxLength(20)
            .IsRequired();

        builder.HasMany<VolumeProjection>()
            .WithOne()
            .HasForeignKey(projection => projection.MangaId)
            .OnDelete(DeleteBehavior.ClientCascade)
            .IsRequired();

        builder.HasMany<GenreProjection>()
            .WithMany()
            .UsingEntity<GenreToMangaProjection>(
                r => r.HasOne<GenreProjection>()
                    .WithMany()
                    .HasForeignKey(projection => projection.GenreName)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.ClientCascade),
                l => l.HasOne<MangaProjection>()
                    .WithMany()
                    .HasForeignKey(projection => projection.MangaId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.ClientCascade),
                j => j.HasKey(j => new
                {
                    j.MangaId, 
                    j.GenreName
                })
            );

        builder.OwnsOne(projection => projection.Cover)
            .WithOwner();
    }
}