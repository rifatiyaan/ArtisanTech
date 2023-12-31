﻿// <auto-generated />
using ArtisanTech.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ArtisanTech.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ArtisanTech.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            DisplayOrder = 1,
                            Name = "Graphics Cards"
                        },
                        new
                        {
                            CategoryId = 2,
                            DisplayOrder = 2,
                            Name = "Motherboard"
                        },
                        new
                        {
                            CategoryId = 3,
                            DisplayOrder = 3,
                            Name = "RAM"
                        });
                });

            modelBuilder.Entity("ArtisanTech.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Company")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Company = "NVIDIA",
                            Description = "The GPU operates at a frequency of 1440 MHz, which can be boosted up to 1710 MHz. The memory runs at 1188 MHz (19 Gbps effective).",
                            ImageUrl = "",
                            Name = "NVIDIA GeForce RTX 3080",
                            Price = 1200000
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 2,
                            Company = "GIGABYTE",
                            Description = "X marks the 14th generation! Introducing the AORUS Z790 X Gen Motherboards, the most powerful platforms ever built for the Intel® Core™ 14th Gen processors. With the leading performance in DDR5 memory, the upgraded DIY-friendly innovations, and the all-new BIOS redesigned as user-centered, the AORUS Z790 X Gen Motherboards are built to fully unleash the next-gen power.",
                            ImageUrl = "",
                            Name = "GIGABYTE Z790 AORUS PRO X ATX Motherboard",
                            Price = 60000
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 3,
                            Company = "AMD",
                            Description = "The AMD Ryzen 9 5950X is a high-performance processor with 16 cores and 32 threads. It has a base clock speed of 3.4 GHz and can boost up to 4.9 GHz. The processor is built on the AMD \"Zen 3\" core architecture and comes with a 64MB L3 cache and an 8MB L2 cache.",
                            ImageUrl = "",
                            Name = "AMD Ryzen 9 5950X Processor",
                            Price = 70000
                        });
                });

            modelBuilder.Entity("ArtisanTech.Models.Product", b =>
                {
                    b.HasOne("ArtisanTech.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}
