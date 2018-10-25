using ChamadaWS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChamadaWS.Repositorio
{
    public interface IAlunoRepositorio
    {
        Aluno FindMatricula(long matricula);
        IEnumerable<Aluno> GetAll();

        //Metodos comentados para uso posterior****************************************
        //void Add(Aluno aluno);
        //Aluno Find(long id);
        //void Remove(long id);
        //void Update(Aluno aluno);
    }
}
