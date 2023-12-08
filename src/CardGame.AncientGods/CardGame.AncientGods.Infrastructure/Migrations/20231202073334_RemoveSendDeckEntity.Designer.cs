﻿// <auto-generated />
using System;
using CardGame.AncientGods.Infrastructure.GameDomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CardGame.AncientGods.Infrastructure.Migrations
{
    [DbContext(typeof(GameDbContext))]
    [Migration("20231202073334_RemoveSendDeckEntity")]
    partial class RemoveSendDeckEntity
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CardGame.AncientGods.Core.GameDomain.Entities.Game", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Deck")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Game", (string)null);
                });

            modelBuilder.Entity("CardGame.AncientGods.Core.GameDomain.Entities.PlayerChoice", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Descriptor")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("GameId")
                        .HasColumnType("uuid");

                    b.Property<int>("PlayerChoiceCardNum")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("PlayerChoice", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
