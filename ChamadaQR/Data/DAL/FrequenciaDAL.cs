﻿using Microsoft.EntityFrameworkCore;
using Modelo.Cadastros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChamadaQR.Data.DAL
{
    public class FrequenciaDAL
    {
        private IESContext _context;

        //Configuracoes do contexto
        public FrequenciaDAL(IESContext context)
        {
            _context = context;
        }

        //Obter Classificacao por Nome
        public IQueryable<Frequencia> ObterFrequenciasClassificadasPorNome()
        {
            return _context.Frequencias.Include(c => c.Calendario)
                                       .Include(a => a.Aluno)                                    
                                       .OrderBy(i => i.Aluno.AlunoNome);
        }

        //Obter Classificacao por ID
        public async Task<Frequencia>ObterFrequenciaPorID(long id)
        {
            //var frequencia = await _context.Frequencias.SingleOrDefaultAsync(p => p.FrequenciaID == id);
            //_context.Calendarios.Where(p => frequencia.DataID == p.DataID).Load(); ;

            var frequencia = 
                await _context.Frequencias.Include(a => a.Aluno).Include(c => c.Calendario)
                                           .SingleOrDefaultAsync(f => f.FrequenciaID == id);
            return frequencia;
        }

        //Gravar
        public async Task<Frequencia> GravarFrequencia(Frequencia frequencia)
        {                    
            _context.Frequencias.Add(frequencia);           
            await _context.SaveChangesAsync();
            return frequencia;
        }

        //Gravar/Atualizar
        public async Task<Frequencia> AtualizarFrequencia(Frequencia frequencia)
        {           
            _context.Update(frequencia);            
            await _context.SaveChangesAsync();
            return frequencia;
        }

        //Deletar
        public async Task<Frequencia> EliminarFrequenciaPorId(long id)
        {
            Frequencia frequencia = await ObterFrequenciaPorID(id);
            _context.Frequencias.Remove(frequencia);
            await _context.SaveChangesAsync();
            return frequencia;
        }
    }
}
