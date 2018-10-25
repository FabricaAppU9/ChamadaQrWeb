using ChamadaWS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChamadaWS.Repositorio
{
    public interface IQrCodeRepositorio
    {
        //void Add(Qrcode qrcode);
        IEnumerable<Qrcode> GetAll();
        Qrcode Find(long id);
        //void Remove(long id);
        //void Update(Qrcode qrcode);
    }
}
