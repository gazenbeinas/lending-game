﻿// <auto-generated />
using LendingGame.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace LendingGame.Web.Migrations
{
    [DbContext(typeof(LendingGameContext))]
    partial class LendingGameContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LendingGame.Domain.Friends.Entities.Friend", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Friends");
                });

            modelBuilder.Entity("LendingGame.Domain.Games.Entities.Game", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("LendingGame.Domain.Loans.Entities.Loan", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FriendId")
                        .IsRequired();

                    b.Property<string>("GameId")
                        .IsRequired();

                    b.Property<DateTime>("LoanDate");

                    b.Property<DateTime?>("ReturnDate");

                    b.HasKey("Id");

                    b.HasIndex("FriendId");

                    b.HasIndex("GameId");

                    b.ToTable("Loans");
                });

            modelBuilder.Entity("LendingGame.Domain.Loans.Entities.Loan", b =>
                {
                    b.HasOne("LendingGame.Domain.Friends.Entities.Friend", "Friend")
                        .WithMany("Loans")
                        .HasForeignKey("FriendId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("LendingGame.Domain.Games.Entities.Game", "BorrowedGame")
                        .WithMany("Loans")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}