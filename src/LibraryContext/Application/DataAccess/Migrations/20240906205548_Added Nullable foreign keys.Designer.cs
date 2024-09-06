﻿// <auto-generated />
using System;
using Inanna.LibraryContext.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Inanna.LibraryContext.Application.DataAccess.Migrations
{
    [DbContext(typeof(LibraryDbContext))]
    [Migration("20240906205548_Added Nullable foreign keys")]
    partial class AddedNullableforeignkeys
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Inanna.LibraryContext.Infrastructure.DataAccess.Models.ChapterModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("VolumeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VolumeId");

                    b.ToTable("Chapters");
                });

            modelBuilder.Entity("Inanna.LibraryContext.Infrastructure.DataAccess.Models.MangaModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("PublisherId")
                        .HasColumnType("int");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Mangas");
                });

            modelBuilder.Entity("Inanna.LibraryContext.Infrastructure.DataAccess.Models.VolumeModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("MangaId")
                        .HasColumnType("int");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("MangaId");

                    b.ToTable("Volumes");
                });

            modelBuilder.Entity("Inanna.LibraryContext.Infrastructure.DataAccess.Models.ChapterModel", b =>
                {
                    b.HasOne("Inanna.LibraryContext.Infrastructure.DataAccess.Models.VolumeModel", "Volume")
                        .WithMany("Chapters")
                        .HasForeignKey("VolumeId");

                    b.OwnsMany("Inanna.LibraryContext.Infrastructure.DataAccess.Models.PageModel", "Pages", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"));

                            b1.Property<int?>("ChapterId")
                                .IsRequired()
                                .HasColumnType("int");

                            b1.Property<int>("Number")
                                .HasColumnType("int");

                            b1.HasKey("Id");

                            b1.HasIndex("ChapterId");

                            b1.ToTable("PageModel");

                            b1.WithOwner("Chapter")
                                .HasForeignKey("ChapterId");

                            b1.OwnsOne("Inanna.LibraryContext.Infrastructure.DataAccess.Models.ImageModel", "Image", b2 =>
                                {
                                    b2.Property<int>("PageModelId")
                                        .HasColumnType("int");

                                    b2.Property<string>("ContentType")
                                        .IsRequired()
                                        .HasColumnType("nvarchar(max)");

                                    b2.Property<string>("Path")
                                        .IsRequired()
                                        .HasColumnType("nvarchar(max)");

                                    b2.HasKey("PageModelId");

                                    b2.ToTable("PageModel");

                                    b2.WithOwner()
                                        .HasForeignKey("PageModelId");
                                });

                            b1.Navigation("Chapter");

                            b1.Navigation("Image")
                                .IsRequired();
                        });

                    b.Navigation("Pages");

                    b.Navigation("Volume");
                });

            modelBuilder.Entity("Inanna.LibraryContext.Infrastructure.DataAccess.Models.MangaModel", b =>
                {
                    b.OwnsMany("Inanna.LibraryContext.Infrastructure.DataAccess.Models.GenreModel", "Genres", b1 =>
                        {
                            b1.Property<string>("Name")
                                .HasMaxLength(20)
                                .HasColumnType("nvarchar(20)");

                            b1.Property<int>("MangaModelId")
                                .HasColumnType("int");

                            b1.HasKey("Name");

                            b1.HasIndex("MangaModelId");

                            b1.ToTable("Genres");

                            b1.WithOwner()
                                .HasForeignKey("MangaModelId");
                        });

                    b.OwnsOne("Inanna.LibraryContext.Infrastructure.DataAccess.Models.ImageModel", "Cover", b1 =>
                        {
                            b1.Property<int>("MangaModelId")
                                .HasColumnType("int");

                            b1.Property<string>("ContentType")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Path")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("MangaModelId");

                            b1.ToTable("Mangas");

                            b1.WithOwner()
                                .HasForeignKey("MangaModelId");
                        });

                    b.Navigation("Cover");

                    b.Navigation("Genres");
                });

            modelBuilder.Entity("Inanna.LibraryContext.Infrastructure.DataAccess.Models.VolumeModel", b =>
                {
                    b.HasOne("Inanna.LibraryContext.Infrastructure.DataAccess.Models.MangaModel", "Manga")
                        .WithMany("Volumes")
                        .HasForeignKey("MangaId");

                    b.Navigation("Manga");
                });

            modelBuilder.Entity("Inanna.LibraryContext.Infrastructure.DataAccess.Models.MangaModel", b =>
                {
                    b.Navigation("Volumes");
                });

            modelBuilder.Entity("Inanna.LibraryContext.Infrastructure.DataAccess.Models.VolumeModel", b =>
                {
                    b.Navigation("Chapters");
                });
#pragma warning restore 612, 618
        }
    }
}
