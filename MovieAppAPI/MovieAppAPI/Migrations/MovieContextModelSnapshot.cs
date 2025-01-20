﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieAppAPI.Data;

#nullable disable

namespace MovieAppAPI.Migrations
{
    [DbContext(typeof(MovieContext))]
    partial class MovieContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MovieAppAPI.Entities.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Action"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Sci-Fi"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Fantasy"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Horror"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Romance"
                        });
                });

            modelBuilder.Entity("MovieAppAPI.Entities.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateOnly>("ReleaseDate")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("GenreId");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            GenreId = 1,
                            Name = "Inception",
                            Price = 12.99m,
                            ReleaseDate = new DateOnly(2003, 1, 1)
                        },
                        new
                        {
                            Id = 2,
                            GenreId = 1,
                            Name = "The Dark Knight",
                            Price = 14.99m,
                            ReleaseDate = new DateOnly(2005, 1, 1)
                        },
                        new
                        {
                            Id = 3,
                            GenreId = 2,
                            Name = "Interstellar",
                            Price = 10.99m,
                            ReleaseDate = new DateOnly(2007, 1, 1)
                        },
                        new
                        {
                            Id = 4,
                            GenreId = 2,
                            Name = "The Matrix",
                            Price = 9.99m,
                            ReleaseDate = new DateOnly(1999, 1, 1)
                        },
                        new
                        {
                            Id = 5,
                            GenreId = 3,
                            Name = "The Lord of the Rings: The Fellowship of the Ring",
                            Price = 11.99m,
                            ReleaseDate = new DateOnly(2001, 1, 1)
                        },
                        new
                        {
                            Id = 6,
                            GenreId = 3,
                            Name = "The Lord of the Rings: The Two Towers",
                            Price = 11.99m,
                            ReleaseDate = new DateOnly(2002, 1, 1)
                        });
                });

            modelBuilder.Entity("MovieAppAPI.Entities.Movie", b =>
                {
                    b.HasOne("MovieAppAPI.Entities.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");
                });
#pragma warning restore 612, 618
        }
    }
}
