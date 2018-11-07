using ChamadaWS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChamadaWS.Repositorio
{
    public interface IFrequenciaRepositorio
    {
        void Add(Frequencia frequencia);
        Frequencia Find(long id);
        IEnumerable<Frequencia> GetAll();
        
        //Metodos comentados para uso posterior****************************************
        //void Remove(long id);
        //void Update(Frequencia frequencia);
    }
}
