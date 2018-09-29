using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChamadaQC.Controllers
{

    public class QrCodeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Generate()
        {
            string senha = "@teste";
            string data = DateTime.Today.ToString("dd/MM/yyyy");
            string dataComposta = data + ";" + senha;
            ViewBag.data = dataComposta.GetHashCode();

            return View("Index");
        }

    }
}