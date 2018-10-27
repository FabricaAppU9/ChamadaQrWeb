using Modelo.Cadastros;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChamadaQR.Data.DAL
{
    public class UnidadeDAL
    {
        private IESContext _context;

        //Configuracoes do contexto
        public UnidadeDAL(IESContext context)
        {
            _context = context;
        }

        //Obter Classificacao por Nome
        public IQueryable<Unidade> ObterUnidadesClassificadosPorNome()
        {
            return _context.Unidades.OrderBy(u => u.UnidadeNome);
        }

        //Obter Classificacao por ID
        public async Task<Unidade> ObterUnidadePorId(long id)
        {
            return await _context.Unidades.SingleOrDefaultAsync(u => u.UnidadeID == id);
        }

        //Gravar
        public async Task<Unidade> GravarUnidade(Unidade unidade)
        {
            if (unidade.UnidadeID == null)
            {
                _context.Unidades.Add(unidade);
            }
            else
            {
                _context.Unidades.Update(unidade);
            }
            await _context.SaveChangesAsync();
            return unidade;
        }

        //Deletar
        public async Task<Unidade> EliminaUnidadePorId(long id)
        {
            Unidade unidade = await ObterUnidadePorId(id);
            _context.Unidades.Remove(unidade);
            await _context.SaveChangesAsync();
            return unidade;
        }
    }
}
