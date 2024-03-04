using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SSR_DataTable_jQuery.Models
{
    public partial class DevelopDBContext : DbContext
    {
        public DevelopDBContext()
        {
        }

        public DevelopDBContext(DbContextOptions<DevelopDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Empleado> Empleados { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("workstation id=DevelopDB.mssql.somee.com;packet size=4096;user id=luisabrade_SQLLogin_1;pwd=atseq4y9u3;data source=DevelopDB.mssql.somee.com;persist security info=False;initial catalog=DevelopDB;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CorreoElectronico).HasMaxLength(100);

                entity.Property(e => e.Domicilio).HasMaxLength(255);

                entity.Property(e => e.Nombre).HasMaxLength(100);

                entity.Property(e => e.Telefono).HasMaxLength(20);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
