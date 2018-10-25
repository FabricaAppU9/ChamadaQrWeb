using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChamadaWS.Models;
using ChamadaWS.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace ChamadaWS.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class QrCodeController : Controller
    {
        private readonly IQrCodeRepositorio _qrcodeRepositorio;

        public QrCodeController(IQrCodeRepositorio qrcodeRepositorio)
        {
            _qrcodeRepositorio = qrcodeRepositorio;
        }

        [HttpGet]
        public IEnumerable<Qrcode> GetAll()
        {
            return _qrcodeRepositorio.GetAll();
        }       
    }
}