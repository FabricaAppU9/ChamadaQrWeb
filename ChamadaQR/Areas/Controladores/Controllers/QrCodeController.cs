using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChamadaQR.Data;
using ChamadaQR.Data.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChamadaQR.Areas.Controladores.Controllers
{
    [Area("Controladores")]
    [Authorize]
    public class QrCodeController : Controller
    {
        private readonly IESContext _context;
        private readonly QrcodeDAL qrcodeDAL;

        public IActionResult Index()
        {
            string data = DateTime.Today.ToString("dd/MM/yyyy");
            ViewBag.data = data.GetHashCode();
            return View();
        }        
    }
}