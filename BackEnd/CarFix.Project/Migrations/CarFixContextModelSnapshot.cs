﻿// <auto-generated />
using System;
using CarFix.Project.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CarFix.Project.Migrations
{
    [DbContext(typeof(CarFixContext))]
    partial class CarFixContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CarFix.Project.Domains.Budget", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("FinalizationDate")
                        .HasColumnType("datetime");

                    b.Property<Guid>("IdVehicle")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("TimeEstimate")
                        .HasColumnType("int");

                    b.Property<decimal?>("TotalValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("VisitDate")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("IdVehicle")
                        .IsUnique();

                    b.ToTable("Budgets");
                });

            modelBuilder.Entity("CarFix.Project.Domains.Service", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime");

                    b.Property<Guid?>("IdBudget")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IdServiceType")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IdUser")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Observations")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ServiceDescription")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("ServiceStatus")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("IdBudget");

                    b.HasIndex("IdServiceType");

                    b.HasIndex("IdUser");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("CarFix.Project.Domains.ServiceImage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime");

                    b.Property<Guid>("IdService")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("IdService");

                    b.ToTable("ServiceImages");
                });

            modelBuilder.Entity("CarFix.Project.Domains.ServiceType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime");

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("ServiceTypes");
                });

            modelBuilder.Entity("CarFix.Project.Domains.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("DateTime");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("UserType")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CarFix.Project.Domains.Vehicle", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BrandName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("IdUser")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LicensePlate")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("ModelName")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.Property<string>("VehicleImage")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdUser");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("CarFix.Project.Domains.Budget", b =>
                {
                    b.HasOne("CarFix.Project.Domains.Vehicle", "Vehicle")
                        .WithOne("Budget")
                        .HasForeignKey("CarFix.Project.Domains.Budget", "IdVehicle")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("CarFix.Project.Domains.Service", b =>
                {
                    b.HasOne("CarFix.Project.Domains.Budget", "Budget")
                        .WithMany("Services")
                        .HasForeignKey("IdBudget");

                    b.HasOne("CarFix.Project.Domains.ServiceType", "ServiceType")
                        .WithMany("Services")
                        .HasForeignKey("IdServiceType");

                    b.HasOne("CarFix.Project.Domains.User", "Worker")
                        .WithMany("Services")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Budget");

                    b.Navigation("ServiceType");

                    b.Navigation("Worker");
                });

            modelBuilder.Entity("CarFix.Project.Domains.ServiceImage", b =>
                {
                    b.HasOne("CarFix.Project.Domains.Service", "Service")
                        .WithMany("ServiceImages")
                        .HasForeignKey("IdService")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Service");
                });

            modelBuilder.Entity("CarFix.Project.Domains.Vehicle", b =>
                {
                    b.HasOne("CarFix.Project.Domains.User", "User")
                        .WithMany("Vehicles")
                        .HasForeignKey("IdUser");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CarFix.Project.Domains.Budget", b =>
                {
                    b.Navigation("Services");
                });

            modelBuilder.Entity("CarFix.Project.Domains.Service", b =>
                {
                    b.Navigation("ServiceImages");
                });

            modelBuilder.Entity("CarFix.Project.Domains.ServiceType", b =>
                {
                    b.Navigation("Services");
                });

            modelBuilder.Entity("CarFix.Project.Domains.User", b =>
                {
                    b.Navigation("Services");

                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("CarFix.Project.Domains.Vehicle", b =>
                {
                    b.Navigation("Budget");
                });
#pragma warning restore 612, 618
        }
    }
}
