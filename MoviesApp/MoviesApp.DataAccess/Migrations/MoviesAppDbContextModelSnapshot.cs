﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MoviesApp.DataAccess;

#nullable disable

namespace MoviesApp.DataAccess.Migrations
{
    [DbContext(typeof(MoviesAppDbContext))]
    partial class MoviesAppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MoviesApp.Domain.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("Genre")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Bar",
                            Genre = 2,
                            Title = "Foo",
                            UserId = 1,
                            Year = 2014
                        },
                        new
                        {
                            Id = 2,
                            Description = "Bar",
                            Genre = 3,
                            Title = "Boo",
                            UserId = 2,
                            Year = 2015
                        },
                        new
                        {
                            Id = 3,
                            Description = "Bar",
                            Genre = 1,
                            Title = "Hoo",
                            UserId = 2,
                            Year = 2016
                        });
                });

            modelBuilder.Entity("MoviesApp.Domain.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("FavoriteGenre")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FavoriteGenre = 2,
                            FirstName = "Draaven",
                            LastName = "Dunklord",
                            Password = "??	?}w???-u`???",
                            Username = "DravenOut"
                        },
                        new
                        {
                            Id = 2,
                            FavoriteGenre = 3,
                            FirstName = "Darius",
                            LastName = "Dunklord",
                            Password = "?A0&?*,\nvd??u?6?",
                            Username = "ddunkelord"
                        });
                });

            modelBuilder.Entity("MoviesApp.Domain.Models.Movie", b =>
                {
                    b.HasOne("MoviesApp.Domain.Models.User", "User")
                        .WithMany("Movies")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MoviesApp.Domain.Models.User", b =>
                {
                    b.Navigation("Movies");
                });
#pragma warning restore 612, 618
        }
    }
}