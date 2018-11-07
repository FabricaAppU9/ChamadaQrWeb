using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Http;

namespace ChamadaWS.Models
{
    public class Frequencia
    {             
        public long? FrequenciaID { get; set; }  
        public long? AlunoID { get; set; }
        public long? DataID { get; set; }
        public string Presenca { get; set; }     
        public string Justificativa { get; set; }        
    }

    public class FrequenciaUpload
    {
        public long? FrequenciaID { get; set; }
        [Required]
        public long? AlunoID { get; set; }
        public long? DataID { get; set; }
        public string Presenca { get; set; }
        public string Justificativa { get; set; }       
    }
}

