﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WeatherForecast.Data;

#nullable disable

namespace WeatherForecast.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231118120647_CreationOfDataBase")]
    partial class CreationOfDataBase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WeatherForecast.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("WeatherForecast.Models.Weather", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CitiId")
                        .HasColumnType("int");

                    b.Property<int>("Clouds")
                        .HasColumnType("int");

                    b.Property<DateTime>("Day")
                        .HasColumnType("datetime2");

                    b.Property<string>("SpeedOfWind")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("SunRise")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("SunSet")
                        .HasColumnType("datetime2");

                    b.Property<float>("Temperature")
                        .HasColumnType("real");

                    b.Property<float>("TemperatureMin")
                        .HasColumnType("real");

                    b.Property<float>("Temperature_Max")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("CitiId");

                    b.ToTable("Weather");
                });

            modelBuilder.Entity("WeatherForecast.Models.Weather", b =>
                {
                    b.HasOne("WeatherForecast.Models.City", "City")
                        .WithMany("Weathers")
                        .HasForeignKey("CitiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("WeatherForecast.Models.City", b =>
                {
                    b.Navigation("Weathers");
                });
#pragma warning restore 612, 618
        }
    }
}
