using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChamadaQR.Data;
using ChamadaQR.Data.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChamadaQR.Controllers
{
    
    public class QrCodeController : Controller
    {       
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Generate(string productId)
        {
            ViewBag.productId = productId;
            return View("Index");
        }

    }
}