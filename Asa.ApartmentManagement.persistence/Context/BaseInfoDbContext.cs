using Asa.ApartmentManagement.Core.BaseInfo.Domain;
using Asa.ApartmentManagement.Core.BaseInfo.DTOs;
using Asa.ApartmentManagement.Core.ChargeCalculation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Asa.ApartmentManagement.Persistence.Context
{
    public class BaseInfoDbContext : DbContext
    {
        public BaseInfoDbContext(DbContextOptions<BaseInfoDbContext> options) : base(options) { }
        public DbSet<BuildingInfo> BuildingInfos { get; set; }
        public DbSet<ApartmentInfo> ApartmentInfos { get; set; }
        public DbSet<ExpenseInfo> ExpenseInfos { get; set; }
        public DbSet<ExpenseCategory> ExpensCategories { get; set; }
        public DbSet<Person> PersonInfos { get; set; }
        public DbSet<OwnerTenant> OwnerTenants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region moxeeds
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApartmentInfo>().Property(a => a.Area).HasColumnType("decimal(10,2)");

            modelBuilder.Entity<ExpenseCategory>().ToTable(nameof(ExpenseCategory)).HasKey(e => e.ExpenseCategoryId);
            modelBuilder.Entity<Person>().ToTable(nameof(Person)).HasKey(e => e.PersonId);
            modelBuilder.Entity<BuildingInfo>().ToTable("Building").HasKey(e => e.BuildingId);
            modelBuilder.Entity<ApartmentInfo>().ToTable("Apartment").HasKey(e => e.ApartmentId);
            modelBuilder.Entity<ExpenseInfo>().ToTable("Expense").HasKey(e => e.ExpenseId);
            modelBuilder.Entity<OwnerTenant>().ToTable("OwnerTenant").HasKey(e => e.OwnerTenantId);
            #endregion
        }

        internal object firstOrDefalt()
        {
            throw new NotImplementedException();
        }
    }
}
