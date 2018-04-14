using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChamadaQrWebAPI.Models
{
    public class ALUNO
    {
        public int id_aluno { get; set; }
        public string nome { get; set; }
        public string sobrenome { get; set; }
        public string semestre { get; set; }
        public string qsc { get; set; }
        public string campus { get; set; }
        /*
         * FKs
        CURSO_id
        PROJETO_id
        CARGO_id
        CONTATO_id*/
    }
}
