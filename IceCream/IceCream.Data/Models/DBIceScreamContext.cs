﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace IceCream.Data.Models
{
    public partial class DBIceScreamContext : DbContext
    {
        public virtual DbSet<IceCreamShop> IceCreamShop { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserDebtor> UserDebtor { get; set; }

        public DBIceScreamContext(DbContextOptions<DBIceScreamContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IceCreamShop>(entity =>
            {
                entity.HasKey(e => e.IdIceCreamShop)
                    .HasName("PK_IceCreamShop");

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

                entity.Property(e => e.Active).HasDefaultValueSql("1");

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

                entity.Property(e => e.ExpiredToken).HasColumnType("datetime");

                entity.Property(e => e.ImageUrl)
                    .HasColumnName("ImageURL")
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.IsAdmin).HasDefaultValueSql("0");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnType("varchar(500)");

                entity.Property(e => e.Token).HasColumnType("varchar(500)");
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