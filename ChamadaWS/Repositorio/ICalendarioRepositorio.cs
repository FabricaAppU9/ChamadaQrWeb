﻿using ChamadaWS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChamadaWS.Repositorio
{
    public interface ICalendarioRepositorio
    {
        Calendario GetDay(DateTime data);
        IEnumerable<Calendario> GetAll();

        //Metodos comentados para uso posterior****************************************
        //void Add(Calendario calendario);
        //Calendario Find(long id);        
        //void Remove(long id);
        //void Update(Calendario calendario);
    }
}
