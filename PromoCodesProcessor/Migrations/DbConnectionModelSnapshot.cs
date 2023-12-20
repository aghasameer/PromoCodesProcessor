﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PromoCodesProcessor;

#nullable disable

namespace PromoCodesProcessor.Migrations
{
    [DbContext(typeof(DbConnection))]
    partial class DbConnectionModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PromoCodesProcessor.Models.Product_Categories", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Product_Categories");
                });

            modelBuilder.Entity("PromoCodesProcessor.Models.Products", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("PromoCodesProcessor.Models.Promo_Codes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Discount_Type")
                        .HasColumnType("int");

                    b.Property<decimal>("Discount_Value")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Minimum_Order")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("Multiple_Use")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Shipping_Free")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Promo_Codes");
                });

            modelBuilder.Entity("PromoCodesProcessor.Models.Promo_Product_Categories", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Category_Id")
                        .HasColumnType("int");

                    b.Property<int?>("Promo_CodesId")
                        .HasColumnType("int");

                    b.Property<int>("Promo_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Promo_CodesId");

                    b.ToTable("Promo_Product_Categories");
                });

            modelBuilder.Entity("PromoCodesProcessor.Models.Promo_Redeems", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Promos_Id")
                        .HasColumnType("int");

                    b.Property<int>("User_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Redeems");
                });

            modelBuilder.Entity("PromoCodesProcessor.Models.Promo_Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("Promo_CodesId")
                        .HasColumnType("int");

                    b.Property<int>("Promo_Id")
                        .HasColumnType("int");

                    b.Property<int>("User_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Promo_CodesId");

                    b.ToTable("Promo_Users");
                });

            modelBuilder.Entity("PromoCodesProcessor.Models.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PromoCodesProcessor.Models.Promo_Product_Categories", b =>
                {
                    b.HasOne("PromoCodesProcessor.Models.Promo_Codes", null)
                        .WithMany("Promo_Categories")
                        .HasForeignKey("Promo_CodesId");
                });

            modelBuilder.Entity("PromoCodesProcessor.Models.Promo_Users", b =>
                {
                    b.HasOne("PromoCodesProcessor.Models.Promo_Codes", null)
                        .WithMany("Promo_Users")
                        .HasForeignKey("Promo_CodesId");
                });

            modelBuilder.Entity("PromoCodesProcessor.Models.Promo_Codes", b =>
                {
                    b.Navigation("Promo_Categories");

                    b.Navigation("Promo_Users");
                });
#pragma warning restore 612, 618
        }
    }
}
