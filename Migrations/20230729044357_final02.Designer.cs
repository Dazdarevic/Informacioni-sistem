﻿// <auto-generated />
using System;
using Informacioni_sistemi___Projekat.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Informacioni_sistemi___Projekat.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230729044357_final02")]
    partial class final02
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Informacioni_sistemi___Projekat.Models.AdvertisingPanel", b =>
                {
                    b.Property<int?>("PanelID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("PanelID"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AdvertisementPhoto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CityArea")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CityID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dimension")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FromDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsMain")
                        .HasColumnType("bit");

                    b.Property<string>("Lights")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumberOfDays")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Price")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PublicId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ToDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserID")
                        .HasColumnType("int");

                    b.HasKey("PanelID");

                    b.HasIndex("CityID");

                    b.HasIndex("UserID");

                    b.ToTable("AdvertisingPanels");
                });

            modelBuilder.Entity("Informacioni_sistemi___Projekat.Models.City", b =>
                {
                    b.Property<int?>("CityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("CityID"));

                    b.Property<string>("NameOfCity")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CityID");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("Informacioni_sistemi___Projekat.Models.CityArea", b =>
                {
                    b.Property<int?>("CityAreaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("CityAreaID"));

                    b.Property<int?>("CityID")
                        .HasColumnType("int");

                    b.Property<string>("NameOfArea")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CityAreaID");

                    b.HasIndex("CityID");

                    b.ToTable("CityAreas");
                });

            modelBuilder.Entity("Informacioni_sistemi___Projekat.Models.Company", b =>
                {
                    b.Property<int?>("companyID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("companyID"));

                    b.Property<bool>("IsMain")
                        .HasColumnType("bit");

                    b.Property<string>("PublicId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserID")
                        .HasColumnType("int");

                    b.Property<string>("companyAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("companyEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("companyLogo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("companyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("companyOwner")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("companyPIB")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("companySector")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("companyTel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("companyTel2")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("companyID");

                    b.HasIndex("UserID");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("Informacioni_sistemi___Projekat.Models.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("AccessToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BirthdayDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserPassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserRole")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Informacioni_sistemi___Projekat.Models.AdvertisingPanel", b =>
                {
                    b.HasOne("Informacioni_sistemi___Projekat.Models.City", "City")
                        .WithMany("AdvertisingPanels")
                        .HasForeignKey("CityID");

                    b.HasOne("Informacioni_sistemi___Projekat.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID");

                    b.Navigation("City");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Informacioni_sistemi___Projekat.Models.CityArea", b =>
                {
                    b.HasOne("Informacioni_sistemi___Projekat.Models.City", "City")
                        .WithMany("CityAreas")
                        .HasForeignKey("CityID");

                    b.Navigation("City");
                });

            modelBuilder.Entity("Informacioni_sistemi___Projekat.Models.Company", b =>
                {
                    b.HasOne("Informacioni_sistemi___Projekat.Models.User", "User")
                        .WithMany("Companies")
                        .HasForeignKey("UserID");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Informacioni_sistemi___Projekat.Models.City", b =>
                {
                    b.Navigation("AdvertisingPanels");

                    b.Navigation("CityAreas");
                });

            modelBuilder.Entity("Informacioni_sistemi___Projekat.Models.User", b =>
                {
                    b.Navigation("Companies");
                });
#pragma warning restore 612, 618
        }
    }
}
