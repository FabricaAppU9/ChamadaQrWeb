﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Cadastros
{
    public class Qrcode
    {
        public long? QrCodeID { get; set; }
        public string Validacao { get; set; }

        public Qrcode(long? qrCodeID, string validacao)
        {
            QrCodeID = qrCodeID;
            Validacao = validacao;
        }      
    }
}
