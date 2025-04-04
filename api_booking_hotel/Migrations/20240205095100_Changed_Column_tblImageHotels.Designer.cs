﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using api_booking_hotel.DBContext;

#nullable disable

namespace api_booking_hotel.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20240205095100_Changed_Column_tblImageHotels")]
    partial class Changed_Column_tblImageHotels
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("api_booking_hotel.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Icon")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("api_booking_hotel.Models.Hotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CheckIn_Time")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("CheckOut_Time")
                        .HasColumnType("datetime2");

                    b.Property<float?>("Favorite")
                        .HasColumnType("real");

                    b.Property<string>("Introduce")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Phone_Number")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Hotels");
                });

            modelBuilder.Entity("api_booking_hotel.Models.HotelUtility", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("HotelId")
                        .HasColumnType("int");

                    b.Property<bool>("Main")
                        .HasColumnType("bit");

                    b.Property<int?>("UtilityId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.HasIndex("UtilityId");

                    b.ToTable("HotelUtilities");
                });

            modelBuilder.Entity("api_booking_hotel.Models.ImageHotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("HotelId")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.ToTable("ImageHotels");
                });

            modelBuilder.Entity("api_booking_hotel.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("City")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("Created_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Full_Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool>("Gender")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Phone_Number")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<bool>("Role")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("Updated_Date")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("api_booking_hotel.Models.Utility", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UtilityCategoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UtilityCategoryId");

                    b.ToTable("Utilities");
                });

            modelBuilder.Entity("api_booking_hotel.Models.UtilityCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.HasKey("Id");

                    b.ToTable("UtilityCategories");
                });

            modelBuilder.Entity("api_booking_hotel.Models.Hotel", b =>
                {
                    b.HasOne("api_booking_hotel.Models.Category", "Category")
                        .WithMany("Hotels")
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("api_booking_hotel.Models.HotelUtility", b =>
                {
                    b.HasOne("api_booking_hotel.Models.Hotel", "Hotel")
                        .WithMany()
                        .HasForeignKey("HotelId");

                    b.HasOne("api_booking_hotel.Models.Utility", "Utility")
                        .WithMany("HotelUtilities")
                        .HasForeignKey("UtilityId");

                    b.Navigation("Hotel");

                    b.Navigation("Utility");
                });

            modelBuilder.Entity("api_booking_hotel.Models.ImageHotel", b =>
                {
                    b.HasOne("api_booking_hotel.Models.Hotel", "Hotel")
                        .WithMany("ImageHotels")
                        .HasForeignKey("HotelId");

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("api_booking_hotel.Models.Utility", b =>
                {
                    b.HasOne("api_booking_hotel.Models.UtilityCategory", "UtilityCategory")
                        .WithMany("Utilities")
                        .HasForeignKey("UtilityCategoryId");

                    b.Navigation("UtilityCategory");
                });

            modelBuilder.Entity("api_booking_hotel.Models.Category", b =>
                {
                    b.Navigation("Hotels");
                });

            modelBuilder.Entity("api_booking_hotel.Models.Hotel", b =>
                {
                    b.Navigation("ImageHotels");
                });

            modelBuilder.Entity("api_booking_hotel.Models.Utility", b =>
                {
                    b.Navigation("HotelUtilities");
                });

            modelBuilder.Entity("api_booking_hotel.Models.UtilityCategory", b =>
                {
                    b.Navigation("Utilities");
                });
#pragma warning restore 612, 618
        }
    }
}
