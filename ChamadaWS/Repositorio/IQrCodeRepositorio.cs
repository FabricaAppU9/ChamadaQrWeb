using ChamadaWS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChamadaWS.Repositorio
{
    public interface IQrCodeRepositorio
    {
        IEnumerable<Qrcode> GetAll();

        //Metodos comentados para uso posterior****************************************
        //void Add(Qrcode qrcode);
        //Qrcode Find(long id);
        //void Remove(long id);
        //void Update(Qrcode qrcode);
    }
}
