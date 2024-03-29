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
    [Migration("20230622084612_DeletePropertyLastHappyDaysCount")]
    partial class DeletePropertyLastHappyDaysCount
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("InnoGotchi_backend.Models.Entity.Farm", b =>
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
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("FarmId");

                    b.HasIndex("FarmName")
                        .IsUnique();

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Farms");
                });

            modelBuilder.Entity("InnoGotchi_backend.Models.Entity.Pet", b =>
                {
                    b.Property<int>("PetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PetId"), 1L, 1);

                    b.Property<DateTime>("AgeDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Body")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Eyes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FarmId")
                        .HasColumnType("int");

                    b.Property<int>("HappyDaysCount")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastHungerLevel")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastThirstyLevel")
                        .HasColumnType("datetime2");

                    b.Property<string>("Mouth")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nose")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PetName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("PetId");

                    b.HasIndex("FarmId");

                    b.HasIndex("PetName")
                        .IsUnique();

                    b.ToTable("Pets");
                });

            modelBuilder.Entity("InnoGotchi_backend.Models.Entity.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<string>("Avatar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

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

                    b.Property<string>("RefreshToken")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TokenCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TokenExpires")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("UserUser", b =>
                {
                    b.Property<int>("IAmColaboratorUserId")
                        .HasColumnType("int");

                    b.Property<int>("MyColaboratorsUserId")
                        .HasColumnType("int");

                    b.HasKey("IAmColaboratorUserId", "MyColaboratorsUserId");

                    b.HasIndex("MyColaboratorsUserId");

                    b.ToTable("UserColab", (string)null);
                });

            modelBuilder.Entity("InnoGotchi_backend.Models.Entity.Farm", b =>
                {
                    b.HasOne("InnoGotchi_backend.Models.Entity.User", "MyUser")
                        .WithOne("MyFarm")
                        .HasForeignKey("InnoGotchi_backend.Models.Entity.Farm", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MyUser");
                });

            modelBuilder.Entity("InnoGotchi_backend.Models.Entity.Pet", b =>
                {
                    b.HasOne("InnoGotchi_backend.Models.Entity.Farm", "Farm")
                        .WithMany("Pets")
                        .HasForeignKey("FarmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Farm");
                });

            modelBuilder.Entity("UserUser", b =>
                {
                    b.HasOne("InnoGotchi_backend.Models.Entity.User", null)
                        .WithMany()
                        .HasForeignKey("IAmColaboratorUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InnoGotchi_backend.Models.Entity.User", null)
                        .WithMany()
                        .HasForeignKey("MyColaboratorsUserId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("InnoGotchi_backend.Models.Entity.Farm", b =>
                {
                    b.Navigation("Pets");
                });

            modelBuilder.Entity("InnoGotchi_backend.Models.Entity.User", b =>
                {
                    b.Navigation("MyFarm");
                });
#pragma warning restore 612, 618
        }
    }
}
