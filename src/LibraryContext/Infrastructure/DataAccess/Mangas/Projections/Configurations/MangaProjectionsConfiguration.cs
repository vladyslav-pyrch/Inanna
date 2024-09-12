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
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(projection => projection.State)
            .IsRequired()
            .HasMaxLength(20);

        builder.HasMany<VolumeProjection>()
            .WithOne()
            .HasForeignKey(projection => projection.MangaId)
            .OnDelete(DeleteBehavior.ClientCascade);

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

        builder.OwnsOne(projection => projection.Cover, navigationBuilder =>
        {
            navigationBuilder.Property(projection => projection.Path)
                .IsRequired();
            navigationBuilder.Property(projection => projection.ContentType)
                .IsRequired();
            navigationBuilder.WithOwner();
        });
    }
}