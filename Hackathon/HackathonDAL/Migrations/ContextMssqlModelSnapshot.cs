﻿// <auto-generated />
using System;
using HackathonDAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HackathonDAL.Migrations
{
    [DbContext(typeof(ContextMssql))]
    partial class ContextMssqlModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Hackathon.DAL.Models.Games", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<Guid>("GameKey")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Gamer1Key")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Gamer1Point")
                        .HasColumnType("int");

                    b.Property<int>("Gamer1Question")
                        .HasColumnType("int");

                    b.Property<Guid>("Gamer2Key")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Gamer2Point")
                        .HasColumnType("int");

                    b.Property<int>("Gamer2Question")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("Hackathon.DAL.Models.Questions", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Answer")
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("QuestionEN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QuestionTR")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("HackathonDAL.Models.Users", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsEnable")
                        .HasColumnType("bit");

                    b.Property<string>("NameSurname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TeamName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
