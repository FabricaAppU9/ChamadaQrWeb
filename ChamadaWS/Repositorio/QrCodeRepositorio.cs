using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChamadaWS.Models;

namespace ChamadaWS.Repositorio
{
    public class QrCodeRepositorio : IQrCodeRepositorio
    {
        private readonly WSDbContext _context;

        public QrCodeRepositorio(WSDbContext context)
        {
            _context = context;
        }

        public Qrcode Find(long id)
        {
            return _context.Qrcodes.FirstOrDefault(q => q.QrCodeID == id);
        }

        public IEnumerable<Qrcode> GetAll()
        {
            return _context.Qrcodes.ToList();
        }
    }
}
