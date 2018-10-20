using Modelo.Cadastros;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using MySql.Data.EntityFrameworkCore;

namespace ChamadaQR.Data
{
    public class IESContext : DbContext
    {
        //Corresponde a classe AlunoDBContext do ChamdaSW
        public IESContext(DbContextOptions<IESContext> options) : base(options){}

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Projeto> Projetos { get; set; }
        public DbSet<Frequencia> Frequencias { get; set; }
        public DbSet<Calendario> Calendarios { get; set; }
        public DbSet<Professor> Professores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Aluno>().ToTable("Aluno");
            modelBuilder.Entity<Projeto>().ToTable("Projeto");
            modelBuilder.Entity<Frequencia>().ToTable("Frequencia");
            modelBuilder.Entity<Calendario>().ToTable("Calendario");
            modelBuilder.Entity<Professor>().ToTable("Professor");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=IESUtfpr;Trusted_Connection=True;MultipleActiveResultSets=true");
            optionsBuilder.UseMySQL("Server=chamada-qr.mysql.database.azure.com;Port=56550;Database=localdb;Uid=azure@chamada-qr;Pwd=6#vWHD_$");
        }
    }
}
