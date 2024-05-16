﻿// <auto-generated />
using System;
using CarManagement.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarManagement.Data.Migrations
{
    [DbContext(typeof(CarManagementContext))]
    [Migration("20240424091213_spGetAllCompanyList")]
    partial class spGetAllCompanyList
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CarManagement.Data.Models.Car", b =>
                {
                    b.Property<int>("CarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CarId"));

                    b.Property<string>("CarModel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CarName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<bool>("Insurance")
                        .HasColumnType("bit");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("CarId");

                    b.HasIndex("CompanyId");

                    b.ToTable("Cars");

                    b.HasData(
                        new
                        {
                            CarId = 1,
                            CarModel = "Alpha",
                            CarName = "Kia seltos",
                            CompanyId = 1,
                            Insurance = true,
                            Price = 14m
                        },
                        new
                        {
                            CarId = 2,
                            CarModel = "Alpha",
                            CarName = "Kia seltos",
                            CompanyId = 1,
                            Insurance = true,
                            Price = 14m
                        },
                        new
                        {
                            CarId = 3,
                            CarModel = "Alpha",
                            CarName = "Kia seltos",
                            CompanyId = 1,
                            Insurance = true,
                            Price = 14m
                        });
                });

            modelBuilder.Entity("CarManagement.Data.Models.CarDetails", b =>
                {
                    b.Property<int>("CarDetail_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CarDetail_Id"));

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<int>("Engine")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfAirbags")
                        .HasColumnType("int");

                    b.Property<decimal>("SafetRating")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Weight")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CarDetail_Id");

                    b.HasIndex("CarId")
                        .IsUnique();

                    b.ToTable("Details");
                });

            modelBuilder.Entity("CarManagement.Data.Models.Company", b =>
                {
                    b.Property<int>("CompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CompanyId"));

                    b.Property<string>("CEO")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("EstablishedDate")
                        .HasColumnType("date");

                    b.Property<bool>("IsFinanceProvider")
                        .HasColumnType("bit");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CompanyId");

                    b.ToTable("Companys");

                    b.HasData(
                        new
                        {
                            CompanyId = 1,
                            CEO = "Ravi sharma",
                            CompanyName = "Kia",
                            EstablishedDate = new DateOnly(2020, 1, 1),
                            IsFinanceProvider = true,
                            Location = "Spain"
                        });
                });

            modelBuilder.Entity("CarManagement.Data.Models.Car", b =>
                {
                    b.HasOne("CarManagement.Data.Models.Company", "Company")
                        .WithMany("Cars")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("CarManagement.Data.Models.CarDetails", b =>
                {
                    b.HasOne("CarManagement.Data.Models.Car", "Car")
                        .WithOne("CarDetails")
                        .HasForeignKey("CarManagement.Data.Models.CarDetails", "CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");
                });

            modelBuilder.Entity("CarManagement.Data.Models.Car", b =>
                {
                    b.Navigation("CarDetails")
                        .IsRequired();
                });

            modelBuilder.Entity("CarManagement.Data.Models.Company", b =>
                {
                    b.Navigation("Cars");
                });
#pragma warning restore 612, 618
        }
    }
}
