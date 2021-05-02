﻿// <auto-generated />
using System;
using CalledWebMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CalledWebMVC.Migrations
{
    [DbContext(typeof(CalledWebMvcContext))]
    [Migration("20210502005846_Occupationlist")]
    partial class Occupationlist
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("CalledWebMVC.Models.Funcionary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("BirthDay")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(60) CHARACTER SET utf8mb4")
                        .HasMaxLength(60);

                    b.Property<int>("Occupation")
                        .HasColumnType("int");

                    b.Property<string>("Phone")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Rg")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Task")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("TypeContract")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Funcionary");
                });
#pragma warning restore 612, 618
        }
    }
}
