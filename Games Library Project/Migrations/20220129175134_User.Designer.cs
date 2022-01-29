﻿// <auto-generated />
using System;
using Games_Library_Project.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Games_Library_Project.Migrations
{
    [DbContext(typeof(GameContext))]
    [Migration("20220129175134_User")]
    partial class User
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Games_Library_Project.Models.Game", b =>
                {
                    b.Property<int>("GameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Available")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GenreId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ImgLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Price")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PublisherId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("StoreLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("GameId");

                    b.HasIndex("GenreId");

                    b.HasIndex("PublisherId");

                    b.ToTable("Game");

                    b.HasData(
                        new
                        {
                            GameId = 1,
                            Available = "All",
                            GenreId = "10Pu",
                            ImgLink = "https://cdn.vox-cdn.com/thumbor/6Wng0B6dz6T2qkPcOdwm-3vuvYg=/1400x1400/filters:format(jpeg)/cdn.vox-cdn.com/uploads/chorus_asset/file/14257423/Switch_Tetris99_ND0213_SCRN_03.jpg",
                            Name = "Tetris",
                            Price = "Free",
                            PublisherId = 1,
                            StoreLink = "https://tetris.com/play-tetris",
                            UserId = 1,
                            Year = 1984
                        },
                        new
                        {
                            GameId = 2,
                            Available = "All",
                            GenreId = "10Ac",
                            ImgLink = "https://cdn.cloudflare.steamstatic.com/steam/apps/70/capsule_616x353.jpg?t=1591048039",
                            Name = "Half-Life",
                            Price = "9.99$",
                            PublisherId = 2,
                            StoreLink = "https://store.steampowered.com/app/70/HalfLife/",
                            UserId = 1,
                            Year = 1998
                        },
                        new
                        {
                            GameId = 3,
                            Available = "All",
                            GenreId = "10Ad",
                            ImgLink = "https://media.contentapi.ea.com/content/dam/eacom/unravel/ea-hero-large-unravel-xl.jpg.adapt.crop16x9.575p.jpg",
                            Name = "Unravel",
                            Price = "19.99$",
                            PublisherId = 3,
                            StoreLink = "https://www.ea.com/en-gb/games/unravel",
                            UserId = 1,
                            Year = 2016
                        },
                        new
                        {
                            GameId = 4,
                            Available = "All",
                            GenreId = "10Ac",
                            ImgLink = "https://quoramarketing.com/wp-content/uploads/2021/05/Fix-CSGO-Download-Incomplete-Replay-Error.jpg",
                            Name = "CS:GO",
                            Price = "Free",
                            PublisherId = 2,
                            StoreLink = "https://store.steampowered.com/app/730/CounterStrike_Global_Offensive/",
                            UserId = 1,
                            Year = 2012
                        });
                });

            modelBuilder.Entity("Games_Library_Project.Models.Genre", b =>
                {
                    b.Property<string>("GenreId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("GenreId");

                    b.ToTable("Genre");

                    b.HasData(
                        new
                        {
                            GenreId = "10Ac",
                            Name = "Action",
                            UserId = 1
                        },
                        new
                        {
                            GenreId = "10Ad",
                            Name = "Adventure",
                            UserId = 1
                        },
                        new
                        {
                            GenreId = "10Pu",
                            Name = "Puzzle",
                            UserId = 1
                        });
                });

            modelBuilder.Entity("Games_Library_Project.Models.Publisher", b =>
                {
                    b.Property<int>("PublisherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("PublisherId");

                    b.ToTable("Publisher");

                    b.HasData(
                        new
                        {
                            PublisherId = 1,
                            Name = "Microsoft",
                            UserId = 1,
                            Year = 1983
                        },
                        new
                        {
                            PublisherId = 2,
                            Name = "Valve",
                            UserId = 1,
                            Year = 1996
                        },
                        new
                        {
                            PublisherId = 3,
                            Name = "EA",
                            UserId = 1,
                            Year = 1983
                        });
                });

            modelBuilder.Entity("Games_Library_Project.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Password = "Admin",
                            UserName = "Admin"
                        },
                        new
                        {
                            UserId = 2,
                            Password = "123",
                            UserName = "123"
                        });
                });

            modelBuilder.Entity("Games_Library_Project.Models.Game", b =>
                {
                    b.HasOne("Games_Library_Project.Models.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Games_Library_Project.Models.Publisher", "Publisher")
                        .WithMany()
                        .HasForeignKey("PublisherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");

                    b.Navigation("Publisher");
                });
#pragma warning restore 612, 618
        }
    }
}
