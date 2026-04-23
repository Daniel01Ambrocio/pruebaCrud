using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace apiEmpresa.Models
{
    public partial class ModelEmpresa : DbContext
    {
        public ModelEmpresa()
            : base("name=ModelEmpresa")
        {
        }

        public virtual DbSet<Empleados> Empleados { get; set; }
        public virtual DbSet<EmpleadosRoles> EmpleadosRoles { get; set; }
        public virtual DbSet<Logs> Logs { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Empleados>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Empleados>()
                .Property(e => e.Apellido)
                .IsUnicode(false);

            modelBuilder.Entity<Empleados>()
                .Property(e => e.CorreoElectronico)
                .IsUnicode(false);

            modelBuilder.Entity<Empleados>()
                .Property(e => e.contrasena)
                .IsUnicode(false);

            modelBuilder.Entity<Empleados>()
                .HasMany(e => e.EmpleadosRoles)
                .WithRequired(e => e.Empleados)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Empleados>()
                .HasMany(e => e.Logs)
                .WithRequired(e => e.Empleados)
                .HasForeignKey(e => e.IDEmpleadoSolicitante)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Logs>()
                .Property(e => e.DescripcionLog)
                .IsUnicode(false);

            modelBuilder.Entity<Roles>()
                .Property(e => e.NombreRol)
                .IsUnicode(false);

            modelBuilder.Entity<Roles>()
                .HasMany(e => e.EmpleadosRoles)
                .WithRequired(e => e.Roles)
                .WillCascadeOnDelete(false);
        }
    }
}
