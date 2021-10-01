﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Projeto_LEG.Modelos;

namespace Projeto_LEG.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20211001220013_v0.6")]
    partial class v06
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Projeto_LEG.Modelos.Member", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Members");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Member");
                });

            modelBuilder.Entity("Projeto_LEG.Modelos.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("ClientUserId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("OrderEnd")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("OrderTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("RestaurantUserId")
                        .HasColumnType("integer");

                    b.Property<string>("Status")
                        .HasColumnType("text");

                    b.HasKey("OrderId");

                    b.HasIndex("ClientUserId");

                    b.HasIndex("RestaurantUserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Projeto_LEG.Modelos.OrderItem", b =>
                {
                    b.Property<int>("OrderItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("OrderId")
                        .HasColumnType("integer");

                    b.Property<int?>("PlateId")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("OrderItemId");

                    b.HasIndex("OrderId");

                    b.HasIndex("PlateId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("Projeto_LEG.Modelos.Plate", b =>
                {
                    b.Property<int>("PlateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.Property<int?>("RestaurantUserId")
                        .HasColumnType("integer");

                    b.HasKey("PlateId");

                    b.HasIndex("RestaurantUserId");

                    b.ToTable("Plates");
                });

            modelBuilder.Entity("Projeto_LEG.Modelos.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");
                });

            modelBuilder.Entity("Projeto_LEG.Modelos.UserCredential", b =>
                {
                    b.HasBaseType("Projeto_LEG.Modelos.Member");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.HasDiscriminator().HasValue("UserCredential");
                });

            modelBuilder.Entity("Projeto_LEG.Modelos.Client", b =>
                {
                    b.HasBaseType("Projeto_LEG.Modelos.User");

                    b.Property<string>("Cpf")
                        .HasColumnType("text");

                    b.HasDiscriminator().HasValue("Client");
                });

            modelBuilder.Entity("Projeto_LEG.Modelos.Restaurant", b =>
                {
                    b.HasBaseType("Projeto_LEG.Modelos.User");

                    b.Property<string>("CloseTime")
                        .HasColumnType("text");

                    b.Property<string>("Cnpj")
                        .HasColumnType("text");

                    b.Property<string>("OpenTime")
                        .HasColumnType("text");

                    b.HasDiscriminator().HasValue("Restaurant");
                });

            modelBuilder.Entity("Projeto_LEG.Modelos.Order", b =>
                {
                    b.HasOne("Projeto_LEG.Modelos.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientUserId");

                    b.HasOne("Projeto_LEG.Modelos.Restaurant", "Restaurant")
                        .WithMany()
                        .HasForeignKey("RestaurantUserId");

                    b.Navigation("Client");

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("Projeto_LEG.Modelos.OrderItem", b =>
                {
                    b.HasOne("Projeto_LEG.Modelos.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId");

                    b.HasOne("Projeto_LEG.Modelos.Plate", "Plate")
                        .WithMany()
                        .HasForeignKey("PlateId");

                    b.Navigation("Order");

                    b.Navigation("Plate");
                });

            modelBuilder.Entity("Projeto_LEG.Modelos.Plate", b =>
                {
                    b.HasOne("Projeto_LEG.Modelos.Restaurant", "Restaurant")
                        .WithMany()
                        .HasForeignKey("RestaurantUserId");

                    b.Navigation("Restaurant");
                });
#pragma warning restore 612, 618
        }
    }
}
