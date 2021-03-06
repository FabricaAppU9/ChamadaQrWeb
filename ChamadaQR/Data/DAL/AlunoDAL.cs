﻿using Modelo.Cadastros;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChamadaQR.Data.DAL
{
    public class AlunoDAL
    {
        private IESContext _context;

        //Configuracoes do contexto
        public AlunoDAL(IESContext context)
        {
            _context = context;
        }

        //Obter Classificacao por Nome
        public IQueryable<Aluno> ObterAlunosClassificadosPorNome()
        {
            return _context.Alunos.Include(i => i.Projeto).OrderBy(b => b.AlunoNome);
        }

        //Obter Classificacao por ID
        public async Task<Aluno> ObterAlunoPorId(long id)
        {
            var aluno = await _context.Alunos.SingleOrDefaultAsync(m => m.AlunoID == id);
            _context.Projetos.Where(i => aluno.ProjetoID == i.ProjetoID).Load(); ;
            return aluno;
        }

        //Gravar
        public async Task<Aluno> GravarAluno(Aluno aluno)
        {
            if (aluno.AlunoID == null)
            {
                _context.Alunos.Add(aluno);
            }
            else
            {
                _context.Update(aluno);
            }
            await _context.SaveChangesAsync();
            return aluno;
        }

        //Deletar
        public async Task<Aluno> EliminarAlunoPorId(long id)
        {
            Aluno aluno = await ObterAlunoPorId(id);
            _context.Alunos.Remove(aluno);
            await _context.SaveChangesAsync();
            return aluno;
        }
    }
}
