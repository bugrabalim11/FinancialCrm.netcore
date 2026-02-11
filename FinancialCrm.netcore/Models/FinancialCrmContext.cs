using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FinancialCrm.netcore.Models;

public partial class FinancialCrmContext : DbContext
{
    public FinancialCrmContext()
    {
    }

    public FinancialCrmContext(DbContextOptions<FinancialCrmContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bank> Banks { get; set; }

    public virtual DbSet<BankProcess> BankProcesses { get; set; }

    public virtual DbSet<Bill> Bills { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Spending> Spendings { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=FinancialCrmDb;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bank>(entity =>
        {
            entity.Property(e => e.BankAccountNumber).HasMaxLength(50);
            entity.Property(e => e.BankBalance).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.BankTitle).HasMaxLength(50);
        });

        modelBuilder.Entity<BankProcess>(entity =>
        {
            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Description).HasMaxLength(250);
            entity.Property(e => e.ProcessType).HasMaxLength(50);

            entity.HasOne(d => d.Bank).WithMany(p => p.BankProcesses)
                .HasForeignKey(d => d.BankId)
                .HasConstraintName("FK_BankProcesses_Banks");
        });

        modelBuilder.Entity<Bill>(entity =>
        {
            entity.Property(e => e.BillAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.BillPeriod).HasMaxLength(50);
            entity.Property(e => e.BillTitle).HasMaxLength(50);
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryName).HasMaxLength(50);
        });

        modelBuilder.Entity<Spending>(entity =>
        {
            entity.Property(e => e.SpendingId).ValueGeneratedOnAdd();
            entity.Property(e => e.SpendingAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.SpendingTitle).HasMaxLength(250);

            entity.HasOne(d => d.SpendingNavigation).WithOne(p => p.Spending)
                .HasForeignKey<Spending>(d => d.SpendingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Spendings_Categories");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.UserName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
