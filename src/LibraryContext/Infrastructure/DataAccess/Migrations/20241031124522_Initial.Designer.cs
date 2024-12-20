﻿// <auto-generated />
using System;
using Inanna.LibraryContext.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Inanna.LibraryContext.Infrastructure.DataAccess.Migrations
{
    [DbContext(typeof(EventStoreDbContext))]
    [Migration("20241031124522_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Inanna.LibraryContext.Infrastructure.DataAccess.StoredEvent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AggregateRootId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AggregateRootIdType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Event")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EventType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("OccuredOn")
                        .HasColumnType("datetime2");

                    b.Property<long>("Position")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Position"));

                    b.HasKey("Id");

                    b.HasIndex("Position")
                        .IsUnique();

                    b.ToTable("StoredEvents");
                });
#pragma warning restore 612, 618
        }
    }
}
