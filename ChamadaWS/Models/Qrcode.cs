using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ChamadaWS.Models
{
    public class Qrcode
    {
        [Key]
        public long? QrCodeID { get; set; }        
        public string Validacao { get; set; }     
    }
}
