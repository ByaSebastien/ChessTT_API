﻿// <auto-generated />
using System;
using Labo.DAL.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Labo.DAL.Migrations
{
    [DbContext(typeof(TournamentContext))]
    [Migration("20220816154909_CreateAdmin")]
    partial class CreateAdmin
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Labo.DL.Entities.Match", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<Guid>("BlackId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Result")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Round")
                        .HasColumnType("int");

                    b.Property<Guid>("TournamentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("WhiteId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("BlackId");

                    b.HasIndex("TournamentId");

                    b.HasIndex("WhiteId");

                    b.ToTable("Match");
                });

            modelBuilder.Entity("Labo.DL.Entities.Tournament", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Categories")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CurrentRound")
                        .HasColumnType("int");

                    b.Property<int?>("EloMax")
                        .HasColumnType("int");

                    b.Property<int?>("EloMin")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndOfRegistrationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Location")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("MaxPlayers")
                        .HasColumnType("int");

                    b.Property<int>("MinPlayers")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("WomenOnly")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Tournaments");
                });

            modelBuilder.Entity("Labo.DL.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Elo")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("EncodedPassword")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("Salt")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("Salt")
                        .IsUnique();

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("696a3a24-6562-481d-a1f5-2e8db7fe3a6f"),
                            BirthDate = new DateTime(1982, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Elo = 1800,
                            Email = "lykhun@gmail.com",
                            EncodedPassword = new byte[] { 22, 88, 40, 3, 100, 246, 189, 205, 105, 223, 192, 49, 115, 19, 226, 44, 9, 250, 210, 122, 145, 248, 36, 232, 90, 176, 234, 8, 150, 44, 49, 125, 59, 48, 126, 90, 136, 61, 92, 180, 72, 128, 198, 51, 179, 142, 207, 23, 216, 71, 77, 129, 181, 116, 10, 40, 138, 213, 191, 174, 206, 90, 89, 37 },
                            Gender = "Male",
                            IsDeleted = false,
                            Role = "Admin",
                            Salt = new Guid("4919a3c2-0e71-4a5a-a908-4687b8a4df47"),
                            Username = "Checkmate"
                        });
                });

            modelBuilder.Entity("TournamentUser", b =>
                {
                    b.Property<Guid>("PlayersId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TournamentsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PlayersId", "TournamentsId");

                    b.HasIndex("TournamentsId");

                    b.ToTable("TournamentUser");
                });

            modelBuilder.Entity("Labo.DL.Entities.Match", b =>
                {
                    b.HasOne("Labo.DL.Entities.User", "Black")
                        .WithMany("MatchesAsBlack")
                        .HasForeignKey("BlackId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Labo.DL.Entities.Tournament", "Tournament")
                        .WithMany("Matches")
                        .HasForeignKey("TournamentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Labo.DL.Entities.User", "White")
                        .WithMany("MatchesAsWhite")
                        .HasForeignKey("WhiteId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Black");

                    b.Navigation("Tournament");

                    b.Navigation("White");
                });

            modelBuilder.Entity("TournamentUser", b =>
                {
                    b.HasOne("Labo.DL.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("PlayersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Labo.DL.Entities.Tournament", null)
                        .WithMany()
                        .HasForeignKey("TournamentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Labo.DL.Entities.Tournament", b =>
                {
                    b.Navigation("Matches");
                });

            modelBuilder.Entity("Labo.DL.Entities.User", b =>
                {
                    b.Navigation("MatchesAsBlack");

                    b.Navigation("MatchesAsWhite");
                });
#pragma warning restore 612, 618
        }
    }
}
