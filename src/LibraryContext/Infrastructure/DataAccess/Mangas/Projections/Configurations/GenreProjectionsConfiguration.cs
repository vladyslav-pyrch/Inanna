using Inanna.LibraryContext.Application.Features.Mangas.Projections;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inanna.LibraryContext.Infrastructure.DataAccess.Mangas.Projections.Configurations;

public class GenreProjectionsConfiguration : IEntityTypeConfiguration<GenreProjection>
{
    public void Configure(EntityTypeBuilder<GenreProjection> builder)
    {
        builder.HasKey(projection => projection.Name);

        builder.Property(projection => projection.Name)
            .ValueGeneratedNever();

        builder.Property(projection => projection.Name)
            .HasMaxLength(20)
            .IsRequired();

        builder.HasMany<MangaProjection>()
            .WithMany()
            .UsingEntity<GenreToMangaProjection>(
                r => r.HasOne<MangaProjection>()
                    .WithMany()
                    .HasForeignKey(projection => projection.MangaId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.ClientCascade),
                l => l.HasOne<GenreProjection>()
                    .WithMany()
                    .HasForeignKey(projection => projection.GenreName)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.ClientCascade),
                j => j.HasKey(j => new
                {
                    j.MangaId,
                    j.GenreName
                })
            );
    }
}