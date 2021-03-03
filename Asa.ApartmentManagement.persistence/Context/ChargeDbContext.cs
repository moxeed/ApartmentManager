using Asa.ApartmentManagement.Core.ChargeCalculation;
using Asa.ApartmentManagement.Core.ChargeCalculation.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Asa.ApartmentManagement.Persistence.Context
{
    public class ChargeDbContext : DbContext
    {
        public ChargeDbContext(DbContextOptions<ChargeDbContext> options) : base(options) { }
        public DbSet<ChargeBuilding> ChargeBuildings { get; set; }
        public DbSet<ChargeApartment> ChargeApartments { get; set; }
        public DbSet<ChargeExpense> ChargeExpenses { get; set; }
        public DbSet<Charge> Charges { get; set; }
        public DbSet<ChargeItem> ChargeItems { get; set; }
        public DbSet<Payer> Payers { get; set; }
        public DbSet<CalculatedChargeDto> CalculatedCharges { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ChargeApartment>().Property(a => a.Area).HasColumnType("decimal(10,2)");
            modelBuilder.Entity<Charge>().ToTable(nameof(Charge));
            modelBuilder.Entity<ChargeExpense>().Ignore(x => x.Formula);
            modelBuilder.Entity<ChargeItem>().ToTable(nameof(ChargeItem));

            modelBuilder.Entity<ChargeBuilding>().ToTable("Building").HasKey(e => e.BuildingId);
            modelBuilder.Entity<ChargeApartment>().ToTable("Apartment").HasKey(e => e.ApartmentId);
            modelBuilder.Entity<ChargeExpense>().ToTable("Expense").HasKey(e => e.ExpenseId);
            modelBuilder.Entity<Payer>().ToTable("OwnerTenant").HasKey(e => e.OwnerTenantId);
            modelBuilder.Entity<CalculatedChargeDto>().ToView("vwCalculatedCharges").HasNoKey();
        }
    }
}
