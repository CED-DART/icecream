using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using IceCream.Data.Models;

namespace IceCream.Data.Context
{
    public partial class IceCreamManagementContext : DbContext
    {
        public virtual DbSet<IceCreamShop> IceCreamShop { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserDebtor> UserDebtor { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"data source=dvp3.dartdigital.com.br\sql2012r2;initial Catalog=IceCreamManagement;User ID=sa;Password=d@rt$q1dvp;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IceCreamShop>(entity =>
            {
                entity.HasKey(e => e.IceCreamShop1)
                    .HasName("PK_IceCreamShop");

                entity.Property(e => e.IceCreamShop1).HasColumnName("IceCreamShop");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnType("varchar(350)");

                entity.Property(e => e.AveragePrice).HasColumnType("money");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.PaymentMethods).HasColumnType("varchar(200)");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnType("varchar(15)");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PK_User");

                entity.Property(e => e.AcceptedTemsDate).HasColumnType("datetime");

                entity.Property(e => e.AdmissionDate).HasColumnType("date");

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.Contact)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnType("varchar(500)");
            });

            modelBuilder.Entity<UserDebtor>(entity =>
            {
                entity.HasKey(e => e.IdUserDebtor)
                    .HasName("PK_UserDebtor");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.DebitDate).HasColumnType("date");

                entity.Property(e => e.Evaluation).HasColumnType("varchar(50)");

                entity.Property(e => e.PaymentDate).HasColumnType("datetime");

                entity.Property(e => e.Reason)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.UserDebtor)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_UserDebtor_User");
            });
        }
    }
}