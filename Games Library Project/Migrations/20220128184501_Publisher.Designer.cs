﻿// <auto-generated />
using Games_Library_Project.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Games_Library_Project.Migrations
{
    [DbContext(typeof(GameContext))]
    [Migration("20220128184501_Publisher")]
    partial class Publisher
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

                    b.Property<int>("PublisherId")
                        .HasColumnType("int");

                    b.Property<string>("StoreLink")
                        .HasColumnType("nvarchar(max)");

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
                            GenreId = "Pu",
                            ImgLink = "https://cdn.vox-cdn.com/thumbor/6Wng0B6dz6T2qkPcOdwm-3vuvYg=/1400x1400/filters:format(jpeg)/cdn.vox-cdn.com/uploads/chorus_asset/file/14257423/Switch_Tetris99_ND0213_SCRN_03.jpg",
                            Name = "Tetris",
                            Price = "Free",
                            PublisherId = 1,
                            StoreLink = "https://tetris.com/play-tetris",
                            Year = 1984
                        },
                        new
                        {
                            GameId = 2,
                            Available = "All",
                            GenreId = "Ac",
                            ImgLink = "https://cdn.cloudflare.steamstatic.com/steam/apps/70/capsule_616x353.jpg?t=1591048039",
                            Name = "Half-Life",
                            Price = "9.99$",
                            PublisherId = 2,
                            StoreLink = "https://store.steampowered.com/app/70/HalfLife/",
                            Year = 1998
                        },
                        new
                        {
                            GameId = 3,
                            Available = "All",
                            GenreId = "Ad",
                            ImgLink = "https://media.contentapi.ea.com/content/dam/eacom/unravel/ea-hero-large-unravel-xl.jpg.adapt.crop16x9.575p.jpg",
                            Name = "Unravel",
                            Price = "19.99$",
                            PublisherId = 3,
                            StoreLink = "https://www.ea.com/en-gb/games/unravel",
                            Year = 2016
                        },
                        new
                        {
                            GameId = 4,
                            Available = "All",
                            GenreId = "Ac",
                            ImgLink = "https://quoramarketing.com/wp-content/uploads/2021/05/Fix-CSGO-Download-Incomplete-Replay-Error.jpg",
                            Name = "CS:GO",
                            Price = "Free",
                            PublisherId = 2,
                            StoreLink = "https://store.steampowered.com/app/730/CounterStrike_Global_Offensive/",
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

                    b.HasKey("GenreId");

                    b.ToTable("Genre");

                    b.HasData(
                        new
                        {
                            GenreId = "Ac",
                            Name = "Action"
                        },
                        new
                        {
                            GenreId = "Ad",
                            Name = "Adventure"
                        },
                        new
                        {
                            GenreId = "Pu",
                            Name = "Puzzle"
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

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("PublisherId");

                    b.ToTable("Publisher");

                    b.HasData(
                        new
                        {
                            PublisherId = 1,
                            Name = "Microsoft",
                            Year = 1983
                        },
                        new
                        {
                            PublisherId = 2,
                            Name = "Valve",
                            Year = 1996
                        },
                        new
                        {
                            PublisherId = 3,
                            Name = "EA",
                            Year = 1983
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
