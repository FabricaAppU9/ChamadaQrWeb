using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChamadaWS.Models;

namespace ChamadaWS.Repositorio
{
    public class CalendarioRepositorio : ICalendarioRepositorio
    {
       
        private readonly WSDbContext _context;

        public CalendarioRepositorio(WSDbContext context)
        {
            _context = context;
        }

        public Calendario GetDay(string data)
        {
            return _context.Calendarios.FirstOrDefault(c => c.DataNome == data);
        }

        public IEnumerable<Calendario> GetAll()
        {
            return _context.Calendarios.ToList();
        }


        //Metodos comentados para uso posterior****************************************

        //public void Add(Calendario calendario)
        //{
        //    _context.Add(calendario);
        //    _context.SaveChanges();
        //}

        //public Calendario Find(long id)
        //{
        //    return _context.Calendarios.FirstOrDefault(c => c.DataID == id);
        //}

        //public void Remove(long id)
        //{
        //    var calendario = _context.Calendarios.FirstOrDefault(c => c.DataID == id);
        //    _context.Calendarios.Remove(calendario);
        //    _context.SaveChanges();
        //}

        //public void Update(Calendario calendario)
        //{
        //    _context.Calendarios.Update(calendario);
        //    _context.SaveChanges();
        //}        
    }
}
