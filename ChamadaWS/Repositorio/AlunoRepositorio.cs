using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChamadaWS.Models;

namespace ChamadaWS.Repositorio
{
    public class AlunoRepositorio : IAlunoRepositorio
    {

        private readonly WSDbContext _context;

        public AlunoRepositorio(WSDbContext context)
        {
            _context = context;
        }

        public Aluno FindMatricula(long matricula)
        {                 
            return _context.Alunos.FirstOrDefault(m => m.Matricula == matricula);
        }

        public IEnumerable<Aluno> GetAll()
        {
            return _context.Alunos.ToList();
        }

        //Metodos comentados para uso posterior****************************************

        //public void Add(Aluno aluno)
        //{
        //    _context.Add(aluno);
        //    _context.SaveChanges();
        //}

        //public Aluno Find(long id)
        //{
        //    return _context.Alunos.FirstOrDefault(a => a.AlunoID == id);
        //}


        //public void Remove(long id)
        //{
        //    var aluno = _context.Alunos.FirstOrDefault(a => a.AlunoID == id);
        //    _context.Alunos.Remove(aluno);
        //    _context.SaveChanges();
        //}

        //public void Update(Aluno aluno)
        //{
        //    _context.Alunos.Update(aluno);
        //    _context.SaveChanges();
        //}
    }
}
