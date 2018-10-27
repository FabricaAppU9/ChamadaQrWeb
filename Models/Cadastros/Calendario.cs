using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Modelo.Cadastros
{
    public class Calendario
    {
        [Key]
        [DisplayName("ID")]
        public long? DataID { get; set; }

        ///[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{dd-MM-yyyy}")]
        [DisplayName("DATA")]
        [Required]
        public string DataNome { get; set; }
        //public DateTime DataNome { get; set; }

        public virtual IEnumerable<Frequencia> Frequencias { get; set; }
    }
}
