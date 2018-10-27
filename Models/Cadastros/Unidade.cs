using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Modelo.Cadastros
{
    public class Unidade
    {      
        [Key]//pk
        [DisplayName("ID")]
        public long? UnidadeID { get; set; }
      
        [Required]
        [DisplayName("ENDERECO")]
        public string UnidadeNome { get; set; }

        [Required]
        [DisplayName("ALIAS")]
        public string  Alias { get; set; }

        [Required]
        [DisplayName("STATUS")]
        public string Status { get; set; }


        public virtual IEnumerable<Projeto> Projetos { get; set; }
    }
}
