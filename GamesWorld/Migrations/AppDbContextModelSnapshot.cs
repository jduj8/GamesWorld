﻿// <auto-generated />
using GamesWorld.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace GamesWorld.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GamesWorld.Data.Models.CartItem", b =>
                {
                    b.Property<int>("CartItemID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Amount");

                    b.Property<string>("CartID");

                    b.Property<int?>("ProductID");

                    b.HasKey("CartItemID");

                    b.HasIndex("ProductID");

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("GamesWorld.Data.Models.Game", b =>
                {
                    b.Property<int>("GameID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int>("GenreID");

                    b.Property<string>("Name");

                    b.HasKey("GameID");

                    b.HasIndex("GenreID");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("GamesWorld.Data.Models.GameConsole", b =>
                {
                    b.Property<int>("GameConsoleID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("GameConsoleName");

                    b.HasKey("GameConsoleID");

                    b.ToTable("GameConsoles");
                });

            modelBuilder.Entity("GamesWorld.Data.Models.Genre", b =>
                {
                    b.Property<int>("GenreID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("GenreName");

                    b.HasKey("GenreID");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("GamesWorld.Data.Models.Order", b =>
                {
                    b.Property<int>("OrderID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<DateTime>("DateOfOrder");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<decimal>("OrderTotal");

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("ZipCode");

                    b.HasKey("OrderID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("GamesWorld.Data.Models.OrderDetail", b =>
                {
                    b.Property<int>("OrderDetailID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Amount");

                    b.Property<int>("OrderID");

                    b.Property<decimal>("Price");

                    b.Property<int>("ProductID");

                    b.HasKey("OrderDetailID");

                    b.HasIndex("OrderID");

                    b.HasIndex("ProductID");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("GamesWorld.Data.Models.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("GameConsoleID");

                    b.Property<int>("GameID");

                    b.Property<string>("ImageUrl");

                    b.Property<bool>("InStock");

                    b.Property<decimal>("Price");

                    b.HasKey("ProductID");

                    b.HasIndex("GameConsoleID");

                    b.HasIndex("GameID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("GamesWorld.Data.Models.CartItem", b =>
                {
                    b.HasOne("GamesWorld.Data.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductID");
                });

            modelBuilder.Entity("GamesWorld.Data.Models.Game", b =>
                {
                    b.HasOne("GamesWorld.Data.Models.Genre", "Genre")
                        .WithMany("Games")
                        .HasForeignKey("GenreID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GamesWorld.Data.Models.OrderDetail", b =>
                {
                    b.HasOne("GamesWorld.Data.Models.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GamesWorld.Data.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GamesWorld.Data.Models.Product", b =>
                {
                    b.HasOne("GamesWorld.Data.Models.GameConsole", "GameConsole")
                        .WithMany("Products")
                        .HasForeignKey("GameConsoleID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GamesWorld.Data.Models.Game", "Game")
                        .WithMany()
                        .HasForeignKey("GameID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
