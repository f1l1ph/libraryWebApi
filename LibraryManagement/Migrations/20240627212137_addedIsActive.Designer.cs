﻿// <auto-generated />
using System;
using ClassLibrary.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LibraryManagement.Migrations
{
    [DbContext(typeof(LibraryContextWrite))]
    [Migration("20240627212137_addedIsActive")]
    partial class addedIsActive
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ClassLibrary.Entities.BookEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("ActiveBorrowOrderId")
                        .HasColumnType("integer");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ActiveBorrowOrderId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("ClassLibrary.Entities.BorrowOrderEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("BookId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CloseDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("OpenDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("User")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("ClassLibrary.Entities.BookEntity", b =>
                {
                    b.HasOne("ClassLibrary.Entities.BorrowOrderEntity", "ActiveBorrowOrder")
                        .WithMany()
                        .HasForeignKey("ActiveBorrowOrderId");

                    b.Navigation("ActiveBorrowOrder");
                });

            modelBuilder.Entity("ClassLibrary.Entities.BorrowOrderEntity", b =>
                {
                    b.HasOne("ClassLibrary.Entities.BookEntity", "Book")
                        .WithMany("BorrowOrders")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");
                });

            modelBuilder.Entity("ClassLibrary.Entities.BookEntity", b =>
                {
                    b.Navigation("BorrowOrders");
                });
#pragma warning restore 612, 618
        }
    }
}
