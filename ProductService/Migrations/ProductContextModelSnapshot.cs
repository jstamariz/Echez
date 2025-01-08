﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProductService.Persistence;

#nullable disable

namespace ProductService.Migrations
{
    [DbContext(typeof(ProductContext))]
    partial class ProductContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("ProductService.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Image")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("ProductService.Models.Product", b =>
                {
                    b.OwnsOne("ProductService.Models.ValueObjects.Description", "Description", b1 =>
                        {
                            b1.Property<int>("ProductId")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(500)
                                .HasColumnType("TEXT")
                                .HasColumnName("Description");

                            b1.HasKey("ProductId");

                            b1.ToTable("Products");

                            b1.WithOwner()
                                .HasForeignKey("ProductId");
                        });

                    b.OwnsOne("ProductService.Models.ValueObjects.Price", "Price", b1 =>
                        {
                            b1.Property<int>("ProductId")
                                .HasColumnType("INTEGER");

                            b1.Property<decimal>("Value")
                                .HasPrecision(18, 2)
                                .HasColumnType("TEXT")
                                .HasColumnName("Price");

                            b1.HasKey("ProductId");

                            b1.ToTable("Products");

                            b1.WithOwner()
                                .HasForeignKey("ProductId");
                        });

                    b.OwnsOne("ProductService.Models.ValueObjects.ProductName", "Name", b1 =>
                        {
                            b1.Property<int>("ProductId")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("TEXT")
                                .HasColumnName("Name");

                            b1.HasKey("ProductId");

                            b1.ToTable("Products");

                            b1.WithOwner()
                                .HasForeignKey("ProductId");
                        });

                    b.Navigation("Description")
                        .IsRequired();

                    b.Navigation("Name")
                        .IsRequired();

                    b.Navigation("Price")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
