using Inanna.LibraryContext.Application.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inanna.LibraryContext.Application.DataAccess.Configurations;

internal class PageModelConfiguration : IEntityTypeConfiguration<PageModel>
{
    public void Configure(EntityTypeBuilder<PageModel> builder)
    {
        builder.HasKey(model => model.Id);

        builder.Property(model => model.Number)
            .IsRequired();

        builder.OwnsOne(model => model.Image, navigationBuilder2 =>
        {
            navigationBuilder2.Property(model => model.Path)
                .IsRequired();
            navigationBuilder2.Property(model => model.ContentType)
                .IsRequired();
            navigationBuilder2.WithOwner();
        });

        builder.HasOne<ChapterModel>()
            .WithMany()
            .HasForeignKey(model => model.ChapterId)
            .OnDelete(DeleteBehavior.ClientCascade);
    }
}