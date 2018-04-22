﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using SportsStoreApi.DataAccess.Ef;
using System;

namespace SportsStoreApi.DataAccess.Ef.Migrations
{
    [DbContext(typeof(SportsStoreDbContext))]
    [Migration("20180422071516_Initial2")]
    partial class Initial2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SportsStoreApi.DataAccess.Category", b =>
                {
                    b.Property<string>("Name")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.HasKey("Name");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("SportsStoreApi.DataAccess.Product", b =>
                {
                    b.Property<string>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("Description")
                        .IsRequired()
                        .IsUnicode(true);

                    b.Property<decimal>("Price");

                    b.HasKey("ProductId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("SportsStoreApi.DataAccess.ProductCategorization", b =>
                {
                    b.Property<string>("CategoryName");

                    b.Property<string>("ProductId");

                    b.HasKey("CategoryName", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductCategorization");
                });

            modelBuilder.Entity("SportsStoreApi.DataAccess.ProductCategorization", b =>
                {
                    b.HasOne("SportsStoreApi.DataAccess.Category", "Category")
                        .WithMany("ProductCategorizations")
                        .HasForeignKey("CategoryName")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SportsStoreApi.DataAccess.Product", "Product")
                        .WithMany("ProductCategorizations")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
