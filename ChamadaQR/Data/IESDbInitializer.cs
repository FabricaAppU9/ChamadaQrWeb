using Modelo.Cadastros;
using System.Linq;

namespace ChamadaQR.Data
{
    public static class IESDbInitializer
    {
        public static void Initialize(IESContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            //Projetos
            if (context.Projetos.Any())            
                return;            

            var projetos = new Projeto[]
            {
                new Projeto { ProjetoNome="ChamadaQR", UnidadeID = 1 },
                new Projeto { ProjetoNome="Agendamentos", UnidadeID = 2}
            };

            foreach (Projeto p in projetos)
            {
                context.Projetos.Add(p);
            }
            context.SaveChanges();            

            //Alunos
            if (context.Alunos.Any())            
                return;            

            var alunos = new Aluno[]
            {
                new Aluno { Matricula = 2515201261, AlunoNome="Primeiro Aluno", Status ="ATIVO", ProjetoID = 1 },
                new Aluno { Matricula = 2515201262, AlunoNome="Segundo Aluno", Status ="ATIVO", ProjetoID = 1 },
                new Aluno { Matricula = 2515201263, AlunoNome="Terceiro Aluno", Status ="ATIVO", ProjetoID = 2 },
                new Aluno { Matricula = 2515201264, AlunoNome="Quarto Aluno", Status ="ATIVO", ProjetoID = 2 }
            };
        
            foreach (Aluno a in alunos)
            {
                context.Alunos.Add(a);
            }
            context.SaveChanges();


            //Professor
            if (context.Professores.Any())            
                return;            

            var professor = new Professor[]
            {
                new Professor { Matricula = 2515201261, ProfessorNome="Primeiro Professor", Status ="ATIVO", ProjetoID = 1 },
                new Professor { Matricula = 2515201262, ProfessorNome="Segundo Professor", Status ="ATIVO", ProjetoID = 2 }
                
            };

            foreach (Professor a in professor)
            {
                context.Professores.Add(a);
            }
            context.SaveChanges();


            //Calendario
            if (context.Calendarios.Any())
                return;

            var calendario = new Calendario[]
            {
                new Calendario { DataNome = "27-10-2018" }
            };

            foreach (Calendario c in calendario)
            {
                context.Calendarios.Add(c);
            }
            context.SaveChanges();

            //Frequencia
            if (context.Frequencias.Any())
                return;

            var frequencias = new Frequencia[]
            {
                new Frequencia { AlunoID = 1, DataID = 1, Presenca = "S" },
                new Frequencia { AlunoID = 2, DataID = 1, Presenca = "S" },
                new Frequencia { AlunoID = 3, DataID = 1, Presenca = "N", Justificativa = "Atestado Medico" },
                new Frequencia { AlunoID = 4, DataID = 1, Presenca = "S" }
            };

            foreach (Frequencia p in frequencias)
            {
                context.Frequencias.Add(p);
            }
            context.SaveChanges();

            //Qrcode
            if (context.Qrcodes.Any())
                return;

            var qrcodes = new Qrcode[]
            {
                new Qrcode(1,"26/10/2018-1-valida")
            };

            foreach (Qrcode q in qrcodes)
            {
                context.Qrcodes.Add(q);
            }
            context.SaveChanges();

            //Unidade
            if (context.Unidades.Any())
                return;

            var unidades = new Unidade[]
            {
                new Unidade { UnidadeNome = "Santo Amaro", Alias = "SA", Status = "ATIVO"},
                new Unidade { UnidadeNome = "Vila Prudente", Alias = "VP", Status = "ATIVO"}
            };

            foreach (Unidade u in unidades)
            {
                context.Unidades.Add(u);
            }
            context.SaveChanges();
        }
    }
}
