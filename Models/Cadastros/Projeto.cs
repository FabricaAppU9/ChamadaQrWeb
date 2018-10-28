using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Modelo.Cadastros
{
    public class Projeto
    {
        [Key]
        [DisplayName("ID")]
        public long? ProjetoID { get; set; }

        [Required]
        [DisplayName("PROJETO")]
        public string ProjetoNome { get; set; }

        [Required]
        [DisplayName("STATUS")]
        public string Status { get; set; } 

        //fk   
        [DisplayName("UNIDADE")]
        public long? UnidadeID { get; set; }
        public Unidade Unidade { get; set; }

        public virtual IEnumerable<Aluno> Alunos { get; set; }
        public virtual IEnumerable<Professor> Professores { get; set; }

    }
}
