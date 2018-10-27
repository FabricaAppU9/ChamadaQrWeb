using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Modelo.Cadastros
{
    public class Professor
    {
        [Key]
        public long? ProfessorID { get; set; }

        [StringLength(10, MinimumLength = 10)]
        [RegularExpression("([0-9]{10})")]
        [DisplayName("RA")]
        [Required]
        public long Matricula { get; set; }

        [Required]
        [DisplayName("NOME")]
        public string ProfessorNome { get; set; }

        [Required]
        [DisplayName("STATUS")]
        public string Status { get; set; }

        //fk
        public long? ProjetoID { get; set; }
        public Projeto Projeto { get; set; }

    }
}
