using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedidorKi.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Extensions;



namespace MedidorKi.Context
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
        {

        }

        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
        }

        //public virtual DbSet<Usuarios> Usuarios { get; set; } = null!;
        public virtual DbSet<Usuario> Usuario { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(local); DataBase=MEKITUsuario;Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__IdUsuario__123456");

                entity.ToTable("MEKITUsuario");

                entity.Property(e => e.NombreUsuario)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CorreoUsuario)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                    entity.Property(e => e.ClaveUsuario)
                    .HasMaxLength(255)
                    .IsUnicode(false);
                    entity.Property(e => e.UsuarioInserto)
                    .HasMaxLength(255)
                    .IsUnicode(false);
                    entity.Property(e => e.FechaInserto)
                    .HasMaxLength(255)
                    .IsUnicode(false);
                    entity.Property(e => e.UsuarioModifico)
                    .HasMaxLength(255)
                    .IsUnicode(false);
                    entity.Property(e => e.FechaModifico)
                    .HasMaxLength(255)
                    .IsUnicode(false);
                    entity.Property(e => e.Estado)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}