using System.Collections.Generic;
using ChamadaWS.Models;
using ChamadaWS.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace ChamadaWS.Controllers
{
    [Route("api/[controller]")]
    public class FrequenciaController : ControllerBase
    {
        private readonly IFrequenciaRepositorio _frequenciaRepositorio;

        public FrequenciaController(IFrequenciaRepositorio frequenciaRepositorio)
        {
            _frequenciaRepositorio = frequenciaRepositorio;
        }

        [HttpPost]
        public IActionResult Create([FromBody]FrequenciaUpload model)
        {
            if (ModelState.IsValid)
            {
                var frequencia = model.ToFrequencia();
                _frequenciaRepositorio.Add(frequencia);
                var uri = Url.Action("GetById", new { id = frequencia.FrequenciaID });
                return Created(uri, frequencia);                
            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            var frequencia = _frequenciaRepositorio.Find(id);
            if (frequencia == null)
            {
                return NotFound();
            }
            return new ObjectResult(frequencia);
        }

        //Metodos comentados para uso posterior****************************************

        [HttpGet]
        public IEnumerable<Frequencia> GetAll()
        {
            return _frequenciaRepositorio.GetAll();
        }

        //[HttpPut("{id}")]
        //public IActionResult Update(long id,[FromBody]Frequencia frequencia)
        //{
        //    if (frequencia == null || frequencia.FrequenciaID != null)
        //    {
        //        return BadRequest();
        //    }

        //    var _frequencia = _frequenciaRepositorio.Find(id);
        //    if (frequencia == null)
        //    {
        //        return NotFound();
        //    }

        //    _frequencia.FrequenciaID = frequencia.FrequenciaID;
        //    _frequenciaRepositorio.Update(_frequencia);
        //    return new NoContentResult();
        //}

        //[HttpDelete("{id}")]
        //public IActionResult Delete(long id)
        //{
        //    var frequencia = _frequenciaRepositorio.Find(id);
        //    if (frequencia == null)
        //    {
        //        return NotFound();
        //    }

        //    _frequenciaRepositorio.Remove(id);
        //    return new NoContentResult();
        //}
    }
}