﻿// <auto-generated />
using System;
using InnoGotchi_backend.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InnoGotchi_backend.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20230209133447_updateUserProp")]
    partial class updateUserProp
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("InnoGotchi_backend.Models.Farm", b =>
                {
                    b.Property<int>("FarmId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FarmId"), 1L, 1);

                    b.Property<int>("AlivePetsCount")
                        .HasColumnType("int");

                    b.Property<int>("DeadPetsCount")
                        .HasColumnType("int");

                    b.Property<string>("FarmName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("FarmId");

                    b.HasIndex("UserId");

                    b.ToTable("Farms");
                });

            modelBuilder.Entity("InnoGotchi_backend.Models.Pet", b =>
                {
                    b.Property<int>("PetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PetId"), 1L, 1);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Body")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Eyes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FarmId")
                        .HasColumnType("int");

                    b.Property<int>("HappyDaysCount")
                        .HasColumnType("int");

                    b.Property<string>("HungerLevel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mouth")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nose")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PetName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ThirstyLevel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PetId");

                    b.HasIndex("FarmId");

                    b.ToTable("Pets");
                });

            modelBuilder.Entity("InnoGotchi_backend.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<string>("Avatar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FarmId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Password")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<int?>("UserId1")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.HasIndex("UserId1");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("InnoGotchi_backend.Models.Farm", b =>
                {
                    b.HasOne("InnoGotchi_backend.Models.User", null)
                        .WithMany("FarmsColaborators")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("InnoGotchi_backend.Models.Pet", b =>
                {
                    b.HasOne("InnoGotchi_backend.Models.Farm", null)
                        .WithMany("Pets")
                        .HasForeignKey("FarmId");
                });

            modelBuilder.Entity("InnoGotchi_backend.Models.User", b =>
                {
                    b.HasOne("InnoGotchi_backend.Models.User", null)
                        .WithMany("Colaborators")
                        .HasForeignKey("UserId1");
                });

            modelBuilder.Entity("InnoGotchi_backend.Models.Farm", b =>
                {
                    b.Navigation("Pets");
                });

            modelBuilder.Entity("InnoGotchi_backend.Models.User", b =>
                {
                    b.Navigation("Colaborators");

                    b.Navigation("FarmsColaborators");
                });
#pragma warning restore 612, 618
        }
    }
}