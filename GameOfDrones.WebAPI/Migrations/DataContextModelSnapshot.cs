﻿// <auto-generated />
using GameOfDrones.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace GameOfDrones.WebAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452");

            modelBuilder.Entity("GameOfDrones.Models.Game", b =>
                {
                    b.Property<int>("GameId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("WinnerPlayerId");

                    b.HasKey("GameId");

                    b.HasIndex("WinnerPlayerId");

                    b.ToTable("Game");
                });

            modelBuilder.Entity("GameOfDrones.Models.Move", b =>
                {
                    b.Property<int>("MoveId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("KillsMoveId");

                    b.Property<string>("Name");

                    b.HasKey("MoveId");

                    b.HasIndex("KillsMoveId");

                    b.ToTable("Move");
                });

            modelBuilder.Entity("GameOfDrones.Models.Player", b =>
                {
                    b.Property<int>("PlayerId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("GameId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<byte>("Number");

                    b.Property<bool>("Winner");

                    b.HasKey("PlayerId");

                    b.HasIndex("GameId");

                    b.ToTable("Player");
                });

            modelBuilder.Entity("GameOfDrones.Models.PlayerMove", b =>
                {
                    b.Property<int>("PlayerMoveId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("MoveId")
                        .IsRequired();

                    b.Property<int?>("PlayerId")
                        .IsRequired();

                    b.Property<int?>("RoundId");

                    b.HasKey("PlayerMoveId");

                    b.HasIndex("MoveId");

                    b.HasIndex("PlayerId");

                    b.HasIndex("RoundId");

                    b.ToTable("PlayerMove");
                });

            modelBuilder.Entity("GameOfDrones.Models.Round", b =>
                {
                    b.Property<int>("RoundId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("GameId");

                    b.Property<int?>("WinnerPlayerId");

                    b.HasKey("RoundId");

                    b.HasIndex("GameId");

                    b.HasIndex("WinnerPlayerId");

                    b.ToTable("Round");
                });

            modelBuilder.Entity("GameOfDrones.Models.Game", b =>
                {
                    b.HasOne("GameOfDrones.Models.Player", "WinnerPlayer")
                        .WithMany()
                        .HasForeignKey("WinnerPlayerId");
                });

            modelBuilder.Entity("GameOfDrones.Models.Move", b =>
                {
                    b.HasOne("GameOfDrones.Models.Move", "Kills")
                        .WithMany()
                        .HasForeignKey("KillsMoveId");
                });

            modelBuilder.Entity("GameOfDrones.Models.Player", b =>
                {
                    b.HasOne("GameOfDrones.Models.Game", "Game")
                        .WithMany("Players")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GameOfDrones.Models.PlayerMove", b =>
                {
                    b.HasOne("GameOfDrones.Models.Move", "Move")
                        .WithMany()
                        .HasForeignKey("MoveId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GameOfDrones.Models.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GameOfDrones.Models.Round")
                        .WithMany("Moves")
                        .HasForeignKey("RoundId");
                });

            modelBuilder.Entity("GameOfDrones.Models.Round", b =>
                {
                    b.HasOne("GameOfDrones.Models.Game", "Game")
                        .WithMany("Rounds")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GameOfDrones.Models.Player", "Winner")
                        .WithMany()
                        .HasForeignKey("WinnerPlayerId");
                });
#pragma warning restore 612, 618
        }
    }
}
