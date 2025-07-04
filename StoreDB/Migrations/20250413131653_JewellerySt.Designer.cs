﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StoreDB.ContextDB;

#nullable disable

namespace StoreDB.Migrations
{
    [DbContext(typeof(SQLServerDBContext))]
    [Migration("20250413131653_JewellerySt")]
    partial class JewellerySt
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("StoreDB.Service.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryID"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("StoreDB.Service.Delivery", b =>
                {
                    b.Property<int>("DeliveryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DeliveryID"));

                    b.Property<DateTime>("DeliveryDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("SupplierID")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("DeliveryID");

                    b.HasIndex("SupplierID");

                    b.ToTable("Deliverys");
                });

            modelBuilder.Entity("StoreDB.Service.DeliveryItem", b =>
                {
                    b.Property<int>("DeliveryItemID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DeliveryItemID"));

                    b.Property<int>("DeliveryID")
                        .HasColumnType("int");

                    b.Property<decimal>("ItemPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("DeliveryItemID");

                    b.HasIndex("DeliveryID");

                    b.HasIndex("ProductID");

                    b.ToTable("DeliveryItems");
                });

            modelBuilder.Entity("StoreDB.Service.Material", b =>
                {
                    b.Property<int>("MaterialID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaterialID"));

                    b.Property<string>("MaterialName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaterialID");

                    b.ToTable("Materials");
                });

            modelBuilder.Entity("StoreDB.Service.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductID"));

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<int>("InStock")
                        .HasColumnType("int");

                    b.Property<int>("MaterialID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("StoneID")
                        .HasColumnType("int");

                    b.Property<decimal>("Weight")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ProductID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("MaterialID");

                    b.HasIndex("StoneID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("StoreDB.Service.Sale", b =>
                {
                    b.Property<int>("SaleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SaleID"));

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("SaleDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("SaleID");

                    b.ToTable("Sales");
                });

            modelBuilder.Entity("StoreDB.Service.SaleItem", b =>
                {
                    b.Property<int>("SaleItemID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SaleItemID"));

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("SaleID")
                        .HasColumnType("int");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("SaleItemID");

                    b.HasIndex("ProductID");

                    b.HasIndex("SaleID");

                    b.ToTable("SaleItems");
                });

            modelBuilder.Entity("StoreDB.Service.Stone", b =>
                {
                    b.Property<int>("StoneID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StoneID"));

                    b.Property<string>("StoneName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StoneID");

                    b.ToTable("Stones");
                });

            modelBuilder.Entity("StoreDB.Service.Supplier", b =>
                {
                    b.Property<int>("SupplierID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SupplierID"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SupplierID");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("StoreDB.Service.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserID"));

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("StoreDB.Service.Delivery", b =>
                {
                    b.HasOne("StoreDB.Service.Supplier", "Supplier")
                        .WithMany("Deliveries")
                        .HasForeignKey("SupplierID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("StoreDB.Service.DeliveryItem", b =>
                {
                    b.HasOne("StoreDB.Service.Delivery", "Delivery")
                        .WithMany("DeliveryItems")
                        .HasForeignKey("DeliveryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StoreDB.Service.Product", "Product")
                        .WithMany("DeliveryItems")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Delivery");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("StoreDB.Service.Product", b =>
                {
                    b.HasOne("StoreDB.Service.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StoreDB.Service.Material", "Material")
                        .WithMany("Products")
                        .HasForeignKey("MaterialID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StoreDB.Service.Stone", "Stone")
                        .WithMany("Products")
                        .HasForeignKey("StoneID");

                    b.Navigation("Category");

                    b.Navigation("Material");

                    b.Navigation("Stone");
                });

            modelBuilder.Entity("StoreDB.Service.SaleItem", b =>
                {
                    b.HasOne("StoreDB.Service.Product", "Product")
                        .WithMany("SaleItems")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StoreDB.Service.Sale", "Sale")
                        .WithMany("SaleItems")
                        .HasForeignKey("SaleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Sale");
                });

            modelBuilder.Entity("StoreDB.Service.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("StoreDB.Service.Delivery", b =>
                {
                    b.Navigation("DeliveryItems");
                });

            modelBuilder.Entity("StoreDB.Service.Material", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("StoreDB.Service.Product", b =>
                {
                    b.Navigation("DeliveryItems");

                    b.Navigation("SaleItems");
                });

            modelBuilder.Entity("StoreDB.Service.Sale", b =>
                {
                    b.Navigation("SaleItems");
                });

            modelBuilder.Entity("StoreDB.Service.Stone", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("StoreDB.Service.Supplier", b =>
                {
                    b.Navigation("Deliveries");
                });
#pragma warning restore 612, 618
        }
    }
}
