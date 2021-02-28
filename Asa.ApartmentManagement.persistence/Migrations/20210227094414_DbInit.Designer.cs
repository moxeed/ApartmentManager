﻿// <auto-generated />
using System;
using Asa.ApartmentManagement.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Asa.ApartmentManagement.Persistence.Migrations
{
    [DbContext(typeof(ChargeDbContext))]
    [Migration("20210227094414_DbInit")]
    partial class DbInit
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Asa.ApartmentManagement.Core.BaseInfo.Domain.ExpenseCategory", b =>
                {
                    b.Property<int>("ExpenseCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ExpenseCategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FormulaType")
                        .HasColumnType("int");

                    b.HasKey("ExpenseCategoryId");

                    b.ToTable("ExpenseCategory");
                });

            modelBuilder.Entity("Asa.ApartmentManagement.Core.BaseInfo.Domain.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PersonId");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("Asa.ApartmentManagement.Core.ChargeCalculation.Charge", b =>
                {
                    b.Property<int>("ChargeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ApartmentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CalculateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("From")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("To")
                        .HasColumnType("datetime2");

                    b.HasKey("ChargeId");

                    b.ToTable("Charge");
                });

            modelBuilder.Entity("Asa.ApartmentManagement.Core.ChargeCalculation.ChargeItem", b =>
                {
                    b.Property<int>("ChargeItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("ChargeId")
                        .HasColumnType("int");

                    b.Property<int>("ExpenseId")
                        .HasColumnType("int");

                    b.Property<int>("PayerId")
                        .HasColumnType("int");

                    b.HasKey("ChargeItemId");

                    b.HasIndex("ChargeId");

                    b.ToTable("ChargeItem");
                });

            modelBuilder.Entity("Asa.ApartmentManagement.Core.ChargeCalculation.Expense", b =>
                {
                    b.Property<int>("ExpenseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("From")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("To")
                        .HasColumnType("datetime2");

                    b.HasKey("ExpenseId");

                    b.ToTable("Expense");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Expense");
                });

            modelBuilder.Entity("Asa.ApartmentManagement.Core.Shared.Apartment", b =>
                {
                    b.Property<int>("ApartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Area")
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("BuildingId")
                        .HasColumnType("int");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.HasKey("ApartmentId");

                    b.HasIndex("BuildingId");

                    b.ToTable("Apartment");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Apartment");
                });

            modelBuilder.Entity("Asa.ApartmentManagement.Core.Shared.Building", b =>
                {
                    b.Property<int>("BuildingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BuildingId");

                    b.ToTable("Building");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Building");
                });

            modelBuilder.Entity("Asa.ApartmentManagement.Core.Shared.OwnerTenant", b =>
                {
                    b.Property<int>("OwnerTenantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ApartmentId")
                        .HasColumnType("int");

                    b.Property<int?>("ApartmentInfoApartmentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("From")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsOwner")
                        .HasColumnType("bit");

                    b.Property<int>("OccupantCount")
                        .HasColumnType("int");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("To")
                        .HasColumnType("datetime2");

                    b.HasKey("OwnerTenantId");

                    b.HasIndex("ApartmentId");

                    b.HasIndex("ApartmentInfoApartmentId");

                    b.HasIndex("PersonId");

                    b.ToTable("OwnerTenant");
                });

            modelBuilder.Entity("Asa.ApartmentManagement.Core.BaseInfo.Domain.ExpenseInfo", b =>
                {
                    b.HasBaseType("Asa.ApartmentManagement.Core.ChargeCalculation.Expense");

                    b.Property<int>("ExpenseCategoryId")
                        .HasColumnType("int");

                    b.HasIndex("ExpenseCategoryId");

                    b.HasDiscriminator().HasValue("ExpenseInfo");
                });

            modelBuilder.Entity("Asa.ApartmentManagement.Core.ChargeCalculation.ChargeExpense", b =>
                {
                    b.HasBaseType("Asa.ApartmentManagement.Core.ChargeCalculation.Expense");

                    b.Property<int>("FormulaType")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("ChargeExpense");
                });

            modelBuilder.Entity("Asa.ApartmentManagement.Core.BaseInfo.Domain.ApartmentInfo", b =>
                {
                    b.HasBaseType("Asa.ApartmentManagement.Core.Shared.Apartment");

                    b.HasDiscriminator().HasValue("ApartmentInfo");
                });

            modelBuilder.Entity("Asa.ApartmentManagement.Core.ChargeCalculation.ChargeApartment", b =>
                {
                    b.HasBaseType("Asa.ApartmentManagement.Core.Shared.Apartment");

                    b.HasDiscriminator().HasValue("ChargeApartment");
                });

            modelBuilder.Entity("Asa.ApartmentManagement.Core.BaseInfo.Domain.BuildingInfo", b =>
                {
                    b.HasBaseType("Asa.ApartmentManagement.Core.Shared.Building");

                    b.Property<int>("ApartmentCount")
                        .HasColumnType("int");

                    b.Property<string>("BuildingName")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("BuildingInfo");
                });

            modelBuilder.Entity("Asa.ApartmentManagement.Core.ChargeCalculation.ChargeBuilding", b =>
                {
                    b.HasBaseType("Asa.ApartmentManagement.Core.Shared.Building");

                    b.HasDiscriminator().HasValue("ChargeBuilding");
                });

            modelBuilder.Entity("Asa.ApartmentManagement.Core.ChargeCalculation.ChargeItem", b =>
                {
                    b.HasOne("Asa.ApartmentManagement.Core.ChargeCalculation.Charge", null)
                        .WithMany("Items")
                        .HasForeignKey("ChargeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Asa.ApartmentManagement.Core.Shared.Apartment", b =>
                {
                    b.HasOne("Asa.ApartmentManagement.Core.Shared.Building", "Building")
                        .WithMany("Apartments")
                        .HasForeignKey("BuildingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Asa.ApartmentManagement.Core.Shared.OwnerTenant", b =>
                {
                    b.HasOne("Asa.ApartmentManagement.Core.Shared.Apartment", "Apartment")
                        .WithMany("Payers")
                        .HasForeignKey("ApartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Asa.ApartmentManagement.Core.BaseInfo.Domain.ApartmentInfo", null)
                        .WithMany("OwnerTenants")
                        .HasForeignKey("ApartmentInfoApartmentId");

                    b.HasOne("Asa.ApartmentManagement.Core.BaseInfo.Domain.Person", "Person")
                        .WithMany("OwnerTenants")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Asa.ApartmentManagement.Core.BaseInfo.Domain.ExpenseInfo", b =>
                {
                    b.HasOne("Asa.ApartmentManagement.Core.BaseInfo.Domain.ExpenseCategory", "ExpenseCategory")
                        .WithMany()
                        .HasForeignKey("ExpenseCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
