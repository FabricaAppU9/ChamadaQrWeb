using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Modelo.Cadastros
{
    public class Qrcode
    {
        [Key]
        public long? QrCodeID { get; set; }
        [Required]
        public string Validacao { get; set; }

        public Qrcode(long? qrCodeID, string validacao)
        {
            QrCodeID = qrCodeID;
            Validacao = validacao;
        }      
    }
}
