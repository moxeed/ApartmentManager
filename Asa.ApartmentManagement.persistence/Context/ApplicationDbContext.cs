using Asa.ApartmentManagement.Core.BaseInfo.Domain;
using Asa.ApartmentManagement.Core.BaseInfo.DTOs;
using Asa.ApartmentManagement.Core.ChargeCalculation;
using Asa.ApartmentManagement.Core.Common;
using Asa.ApartmentManagement.Core.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Asa.ApartmentManagement.Persistence.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base() { }

        public ApplicationDbContext(DbContextOptions options) : base(options) { }


        public DbSet<BuildingInfo> BuildingInfos { get; set; }
        public DbSet<ApartmentInfo> ApartmentInfos { get; set; }
        public DbSet<ExpenseInfo> ExpenseInfos { get; set; }
        public DbSet<ExpenseCategory> ExpensCategories { get; set; }
        public DbSet<Person> PersonInfos { get; set; }
        public DbSet<OwnerTenant> OwnerTenants { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Apartment> Apartments { get; set; }

        public DbSet<ChargeBuilding> ChargeBuildings { get; set; }
        public DbSet<ChargeApartment> ChargeApartments { get; set; }
        public DbSet<ChargeExpense> ChargeExpenses { get; set; }
        public DbSet<Charge> Charges { get; set; }
        public DbSet<ChargeItem> ChargeItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Apartment>().Property(a => a.Area).HasColumnType("decimal(10,2)");
            modelBuilder.Entity<ChargeExpense>().Ignore(x => x.Formula);

            modelBuilder.Entity<Building>().ToTable(nameof(Building));
            modelBuilder.Entity<Apartment>().ToTable(nameof(Apartment));
            modelBuilder.Entity<Expense>().ToTable(nameof(Expense));
            modelBuilder.Entity<ExpenseCategory>().ToTable(nameof(ExpenseCategory));
            modelBuilder.Entity<Charge>().ToTable(nameof(Charge));
            modelBuilder.Entity<ChargeItem>().ToTable(nameof(ChargeItem));
            modelBuilder.Entity<OwnerTenant>().ToTable(nameof(OwnerTenant));
            modelBuilder.Entity<Person>().ToTable(nameof(Person));
        }
    }
}
