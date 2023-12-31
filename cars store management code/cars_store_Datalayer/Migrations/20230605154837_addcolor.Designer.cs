﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using cars_store_Datalayer;

#nullable disable

namespace cars_store_Datalayer.Migrations
{
    [DbContext(typeof(databasecontext))]
    [Migration("20230605154837_addcolor")]
    partial class addcolor
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("cars_store_Domain.Cars", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("KM")
                        .HasColumnType("float");

                    b.Property<string>("gear")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("year")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("tabel_cars");
                });

            modelBuilder.Entity("cars_store_Domain.coustomer", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("age")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("tabel_Costomer");
                });

            modelBuilder.Entity("cars_store_Domain.parts", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("partname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("price")
                        .HasColumnType("float");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.Property<int>("supplierid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("tabel_parts");
                });

            modelBuilder.Entity("cars_store_Domain.parts_cars", b =>
                {
                    b.Property<int>("listcarsid")
                        .HasColumnType("int");

                    b.Property<int>("listpartsid")
                        .HasColumnType("int");

                    b.Property<DateTime>("fix")
                        .HasColumnType("datetime2");

                    b.HasKey("listcarsid", "listpartsid");

                    b.HasIndex("listpartsid");

                    b.ToTable("parts_cars");
                });

            modelBuilder.Entity("cars_store_Domain.sales", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("carid")
                        .HasColumnType("int");

                    b.Property<int>("coustomerid")
                        .HasColumnType("int");

                    b.Property<int>("total")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("tabel_sales");
                });

            modelBuilder.Entity("cars_store_Domain.suppliers", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("suppliername")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("tabel_suppliers");
                });

            modelBuilder.Entity("cars_store_Domain.parts_cars", b =>
                {
                    b.HasOne("cars_store_Domain.Cars", null)
                        .WithMany()
                        .HasForeignKey("listcarsid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("cars_store_Domain.parts", null)
                        .WithMany()
                        .HasForeignKey("listpartsid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
