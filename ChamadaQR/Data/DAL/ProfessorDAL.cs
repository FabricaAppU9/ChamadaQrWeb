using Microsoft.EntityFrameworkCore;
using Modelo.Cadastros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChamadaQR.Data.DAL
{
    public class ProfessorDAL
    {
        private IESContext _context;

        //Configuracoes do contexto
        public ProfessorDAL(IESContext context)
        {
            _context = context;
        }

        //Obter Classificacao por Nome
        public IQueryable<Professor> ObterProfessoresClassificadosPorNome()
        {
            return _context.Professores.Include(i => i.Projeto).OrderBy(b => b.ProfessorNome);
         
        }

        //Obter Classificacao por ID
        public async Task<Professor> ObterProfessorPorId(long id)
        {
            var professor = await _context.Professores.SingleOrDefaultAsync(p => p.ProfessorID == id);
            _context.Projetos.Where(i => professor.ProjetoID == i.ProjetoID).Load(); ;
            return professor;
        }

        //Gravar
        public async Task<Professor> GravarProfessor(Professor professor)
        {
            if (professor.ProfessorID == null)
            {
                _context.Professores.Add(professor);
            }
            else
            {
                _context.Update(professor);
            }
            await _context.SaveChangesAsync();
            return professor;
        }

        //Deletar
        public async Task<Professor> EliminarProfessorPorId(long id)
        {
            Professor professor = await ObterProfessorPorId(id);
            _context.Professores.Remove(professor);
            await _context.SaveChangesAsync();
            return professor;
        }
    }
}
