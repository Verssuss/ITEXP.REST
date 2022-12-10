﻿// <auto-generated />
using System;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ITEXPContext))]
    [Migration("20221210133731_DataFill")]
    partial class DataFill
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("Domain.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("TodoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("TodoId");

                    b.ToTable("Comment");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Text = "2-3шт.",
                            TodoId = 1
                        });
                });

            modelBuilder.Entity("Domain.Entities.Todo", b =>
                {
                    b.Property<string>("Header")
                        .HasColumnType("TEXT");

                    b.Property<byte>("Category")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("TEXT");

                    b.Property<int>("Id")
                        .HasColumnType("INTEGER");

                    b.Property<byte>("Status")
                        .HasColumnType("INTEGER");

                    b.HasKey("Header", "Category");

                    b.ToTable("Todo");

                    b.HasData(
                        new
                        {
                            Header = "Create a ticket",
                            Category = (byte)3,
                            Color = "Red",
                            CreatedOn = new DateTime(2022, 12, 10, 13, 37, 31, 865, DateTimeKind.Utc).AddTicks(4741),
                            Id = 1,
                            Status = (byte)0
                        },
                        new
                        {
                            Header = "Request information",
                            Category = (byte)1,
                            Color = "Green",
                            CreatedOn = new DateTime(2022, 12, 10, 13, 37, 31, 865, DateTimeKind.Utc).AddTicks(4743),
                            Id = 2,
                            Status = (byte)0
                        });
                });

            modelBuilder.Entity("Domain.Entities.Comment", b =>
                {
                    b.HasOne("Domain.Entities.Todo", "Todo")
                        .WithMany("Comments")
                        .HasForeignKey("TodoId")
                        .HasPrincipalKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Todo");
                });

            modelBuilder.Entity("Domain.Entities.Todo", b =>
                {
                    b.Navigation("Comments");
                });
#pragma warning restore 612, 618
        }
    }
}
