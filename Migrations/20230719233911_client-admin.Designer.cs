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
    [Migration("20230719233911_client-admin")]
    partial class clientadmin
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

                    b.Property<string>("CityArea")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CityID")
                        .HasColumnType("int");

                    b.Property<string>("Dimensions")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Height")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Light")
                        .HasColumnType("bit");

                    b.HasKey("PanelID");

                    b.HasIndex("CityID");

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

                    b.Property<string>("Discriminator")
                        .IsRequired()
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

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Informacioni_sistemi___Projekat.Models.Admin", b =>
                {
                    b.HasBaseType("Informacioni_sistemi___Projekat.Models.User");

                    b.Property<string>("AdministratorskaSifra")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Admin");
                });

            modelBuilder.Entity("Informacioni_sistemi___Projekat.Models.Client", b =>
                {
                    b.HasBaseType("Informacioni_sistemi___Projekat.Models.User");

                    b.Property<string>("AddressOfCompany")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Company")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameOfCall")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PIB")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Client");
                });

            modelBuilder.Entity("Informacioni_sistemi___Projekat.Models.AdvertisingPanel", b =>
                {
                    b.HasOne("Informacioni_sistemi___Projekat.Models.City", "City")
                        .WithMany("AdvertisingPanels")
                        .HasForeignKey("CityID");

                    b.Navigation("City");
                });

            modelBuilder.Entity("Informacioni_sistemi___Projekat.Models.City", b =>
                {
                    b.Navigation("AdvertisingPanels");
                });
#pragma warning restore 612, 618
        }
    }
}
