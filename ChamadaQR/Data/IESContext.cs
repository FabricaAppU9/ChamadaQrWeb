using Modelo.Cadastros;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ChamadaQR.Models.Infra;

namespace ChamadaQR.Data
{
    public class IESContext : IdentityDbContext<UsuarioDaAplicacao>
    {
        //Corresponde a classe AlunoDBContext do ChamdaSW
        public IESContext(DbContextOptions<IESContext> options) : base(options){}

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Projeto> Projetos { get; set; }
        public DbSet<Frequencia> Frequencias { get; set; }
        public DbSet<Calendario> Calendarios { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Qrcode> Qrcodes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Aluno>().ToTable("Aluno");
            modelBuilder.Entity<Projeto>().ToTable("Projeto");
            modelBuilder.Entity<Frequencia>().ToTable("Frequencia");
            modelBuilder.Entity<Calendario>().ToTable("Calendario");
            modelBuilder.Entity<Professor>().ToTable("Professor");
            modelBuilder.Entity<Qrcode>().ToTable("Qrcode");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=IESUtfpr;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}
