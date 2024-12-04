﻿// <auto-generated />
using System;
using HW15.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HW15.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241204082710_fix")]
    partial class fix
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HW15.Entities.Card", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<float>("Balance")
                        .HasColumnType("real");

                    b.Property<string>("CardNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.Property<int>("WrongPassTry")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("Cards", (string)null);

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Balance = 65f,
                            CardNumber = "6037697604053527",
                            IsActive = true,
                            Password = "3030",
                            UserID = 1,
                            WrongPassTry = 0
                        },
                        new
                        {
                            ID = 2,
                            Balance = 200f,
                            CardNumber = "6219861967053066",
                            IsActive = true,
                            Password = "3030",
                            UserID = 2,
                            WrongPassTry = 0
                        });
                });

            modelBuilder.Entity("HW15.Entities.Transaction", b =>
                {
                    b.Property<int>("TransactionsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TransactionsId"));

                    b.Property<float>("Amount")
                        .HasColumnType("real");

                    b.Property<int>("DestinationCardNumberID")
                        .HasColumnType("int");

                    b.Property<float?>("Fee")
                        .HasColumnType("real");

                    b.Property<bool>("IsSuccessful")
                        .HasColumnType("bit");

                    b.Property<int>("SourceCardNumberId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("datetime2");

                    b.HasKey("TransactionsId");

                    b.HasIndex("DestinationCardNumberID");

                    b.HasIndex("SourceCardNumberId");

                    b.ToTable("Transaction", (string)null);
                });

            modelBuilder.Entity("HW15.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CardNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Ali"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Reza"
                        });
                });

            modelBuilder.Entity("HW15.Entities.Card", b =>
                {
                    b.HasOne("HW15.Entities.User", "owner")
                        .WithMany("Cards")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("owner");
                });

            modelBuilder.Entity("HW15.Entities.Transaction", b =>
                {
                    b.HasOne("HW15.Entities.Card", "DestinationCard")
                        .WithMany("RecivedTransaction")
                        .HasForeignKey("DestinationCardNumberID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HW15.Entities.Card", "SourceCard")
                        .WithMany("SentTransaction")
                        .HasForeignKey("SourceCardNumberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DestinationCard");

                    b.Navigation("SourceCard");
                });

            modelBuilder.Entity("HW15.Entities.Card", b =>
                {
                    b.Navigation("RecivedTransaction");

                    b.Navigation("SentTransaction");
                });

            modelBuilder.Entity("HW15.Entities.User", b =>
                {
                    b.Navigation("Cards");
                });
#pragma warning restore 612, 618
        }
    }
}
