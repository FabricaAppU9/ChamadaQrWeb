using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChamadaWS.Models
{
    public class WSDbContext : DbContext
    {
        public WSDbContext(DbContextOptions<WSDbContext> options) : base(options) { }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Frequencia> Frequencias { get; set; }
        public DbSet<Calendario> Calendarios { get; set; }
        public DbSet<Qrcode> Qrcodes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Aluno>().ToTable("Aluno");
            modelBuilder.Entity<Frequencia>().ToTable("Frequencia");
            modelBuilder.Entity<Calendario>().ToTable("Calendario");
            modelBuilder.Entity<Qrcode>().ToTable("Qrcode");
        }
    }
}//https://www.youtube.com/watch?v=li_vY4vJbA4
