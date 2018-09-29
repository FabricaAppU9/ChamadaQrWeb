using Microsoft.EntityFrameworkCore;
using Modelo.Cadastros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChamadaQR.Data.DAL
{
    public class QrcodeDAL
    {
        private IESContext _context;

        //Configuracoes do contexto
        public QrcodeDAL(IESContext context)
        {
            _context = context;
        }

        //Obter Classificacao por Nome
        public IQueryable<Qrcode> ObterQrcodeClassificadoPorNome()
        {
            return _context.Qrcodes.OrderBy(q => q.Validacao);
        }

        //Obter Classificacao por ID
        public async Task<Qrcode> ObterQrcodePorId(long id)
        {
            return await _context.Qrcodes.SingleOrDefaultAsync(q => q.QrCodeID == id);
        }

        //Gravar
        public async Task<Qrcode> GravarQrcode(Qrcode qrcode)
        {
            if (qrcode.QrCodeID == null)
            {
                _context.Qrcodes.Add(qrcode);
            }
            else
            {
                _context.Qrcodes.Update(qrcode);
            }
            await _context.SaveChangesAsync();
            return qrcode;
        }

        //Deletar
        public async Task<Qrcode> EliminarQrcodePorId(long id)
        {
            Qrcode qrcode = await ObterQrcodePorId(id);
            _context.Qrcodes.Remove(qrcode);
            await _context.SaveChangesAsync();
            return qrcode;
        }

       //A validacao do qrcode devera ter apenas uma linha na tabela
       //essa validacao devera ser substituida e nao excluida
       //apenas o update deve ser utilizado neste caso
       
    }
}
