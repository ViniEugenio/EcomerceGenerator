﻿// <auto-generated />
using System;
using EcommerceGenerator.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EcommerceGenerator.Infrastructure.Persistence.Migrations.AdminMigrations
{
    [DbContext(typeof(AdminContext))]
    [Migration("20221022234737_FirstMigration")]
    partial class FirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EcommerceGenerator.Domain.Entites.Admin.Client", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("smalldatetime");

                    b.Property<string>("DataBase")
                        .IsRequired()
                        .HasColumnType("varchar(500)");

                    b.Property<string>("Host")
                        .IsRequired()
                        .HasColumnType("varchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(500)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("smalldatetime");

                    b.HasKey("Id");

                    b.ToTable("Client");
                });
#pragma warning restore 612, 618
        }
    }
}