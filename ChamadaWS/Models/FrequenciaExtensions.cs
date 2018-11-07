using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace ChamadaWS.Models
{
    public static class FrequenciaExtensions
    {

        public static Frequencia ToFrequencia(this FrequenciaUpload model)
        {
            return new Frequencia
            {
                FrequenciaID = model.FrequenciaID,
                AlunoID = model.AlunoID,
                DataID = model.DataID,
                Presenca = model.Presenca,
                Justificativa = model.Justificativa
            };
        }

        //public static FrequenciaUpload ToModel(this Frequencia frequencia)
        //{
        //    return new FrequenciaUpload
        //    {
        //        FrequenciaID = frequencia.FrequenciaID,
        //        AlunoID = frequencia.AlunoID,
        //        DataID = frequencia.DataID,
        //        Presenca = frequencia.Presenca,
        //        Justificativa = frequencia.Justificativa
        //    };
        //}

    }
}
