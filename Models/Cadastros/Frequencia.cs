using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Modelo.Cadastros
{
    public class Frequencia
    {
        [Key]
        public long? FrequenciaID { get; set; }

        //fk
        [DisplayName("ALUNO")]
        public long? AlunoID { get; set; }
        public Aluno Aluno { get; set; }

        //fk
        [DisplayName("DATA")]
        public long? DataID { get; set; }
        public Calendario Calendario { get; set; }

        [DisplayName("PRESENCA")]
        public string Presenca { get; set; }
        [DisplayName("JUSTIFICATIVA")]
        public string Justificativa { get; set; }

    }
}
