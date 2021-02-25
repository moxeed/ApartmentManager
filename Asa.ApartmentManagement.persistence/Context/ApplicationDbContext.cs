using Asa.ApartmentManagement.Core.BaseInfo.Domain;
using Asa.ApartmentManagement.Core.BaseInfo.DTOs;
using Asa.ApartmentManagement.Core.ChargeCalculation;
using Microsoft.EntityFrameworkCore;

namespace Asa.ApartmentManagement.Persistence.Context
{
    public class ApplicationDbContext : DbContext 
    {
        public ApplicationDbContext() : base() { }

        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<BuildingInfo> BuildingInfos { get; set; }
        public DbSet<ApartmentInfo> ApartmentInfos { get; set; }
        public DbSet<ExpenseInfo> ExpenseInfos { get; set; }
        public DbSet<ExpensCategory> ExpensCategories { get; set; }
        public DbSet<PersonInfo> PersonInfos { get; set; }
        public DbSet<OwnerTenant> OwnerTenants{ get; set; }

        public DbSet<Building> Buildings { get; set; }
        public DbSet<Apartment> Apartments{ get; set; }
        public DbSet<Expense> Expenses{ get; set; }
        public DbSet<Charge> Charges{ get; set; }
        public DbSet<ChargeItem> ChargeItems{ get; set; }
        public DbSet<Payer> Payers{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var type in modelBuilder.Model.GetEntityTypes())
                modelBuilder.Entity(type.ClrType).ToTable(type.ClrType.Name);

            modelBuilder.Entity<Apartment>().Property(c => c.Area).HasColumnType("decimal(10,2)");
            modelBuilder.Entity<ApartmentInfo>().ToTable(nameof(Apartment)).HasKey(c => c.ApartmentId);
            modelBuilder.Entity<ApartmentInfo>().Property(c => c.Area).HasColumnType("decimal(10,2)");
            modelBuilder.Entity<ApartmentInfo>().HasOne<Apartment>().WithOne().HasForeignKey<ApartmentInfo>(c => c.ApartmentId);

            modelBuilder.Entity<BuildingInfo>().ToTable(nameof(Building)).HasKey(c => c.BuildingId);
            modelBuilder.Entity<BuildingInfo>().HasOne<Building>().WithOne().HasForeignKey<BuildingInfo>(c => c.BuildingId);

            modelBuilder.Entity<Expense>().Ignore(c => c.Formula);
            modelBuilder.Entity<ExpenseInfo>().ToTable(nameof(Expense)).HasKey(c => c.ExpensId);
            modelBuilder.Entity<ExpenseInfo>().Property(c => c.ExpensId).UseIdentityColumn();
            modelBuilder.Entity<ExpenseInfo>().HasOne<Expense>().WithOne().HasForeignKey<ExpenseInfo>(c => c.ExpensId);

            modelBuilder.Entity<Payer>().ToTable("Person");
            modelBuilder.Entity<PersonInfo>().ToTable("Person").HasKey(c => c.PersonId);
            modelBuilder.Entity<PersonInfo>().HasOne<Payer>().WithOne().HasForeignKey<PersonInfo>(c => c.PersonId);

            modelBuilder.Entity<ChargeItem>().HasOne<Payer>().WithMany().HasForeignKey(c => c.PayerId);
            modelBuilder.Entity<ChargeItem>().HasOne<Expense>().WithMany().HasForeignKey(c => c.ExpensId);
            modelBuilder.Entity<ChargeItem>().HasOne<Charge>().WithMany().HasForeignKey(c => c.ChargeId);

            modelBuilder.Entity<Charge>().HasOne<Apartment>().WithMany().HasForeignKey(c => c.ApartmentId);
        }
    }
}
