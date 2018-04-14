using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ChamadaQrWebAPI.Models
{
    public class ChamadaQrContext : DbContext
    {
        public ChamadaQrContext(DbContextOptions<ChamadaQrContext> options)
            : base(options)
        {
        }
        public DbSet<ALUNO> Alunos { get; set; }
    }
}