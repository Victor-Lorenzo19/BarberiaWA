using System;
using System.Collections.Generic;
using BarberiaWA.BD.Datos.Entity;
using Microsoft.EntityFrameworkCore;

namespace BarberiaWA.BD.Datos
{
    public class AppDbcontext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<Turno> Turnos { get; set; }

        public AppDbcontext(DbContextOptions<AppDbcontext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Servicio>()
      .Property(s => s.Precio)
      .HasPrecision(10, 2);
        }
    }
}