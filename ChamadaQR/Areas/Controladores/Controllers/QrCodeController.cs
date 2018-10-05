using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using ChamadaQR.Data;
using ChamadaQR.Data.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Modelo.Cadastros;

namespace ChamadaQR.Areas.Controladores.Controllers
{
    [Area("Controladores")]
    [Authorize]
    public class QrCodeController : Controller
    {
        private readonly IESContext _context;
        private readonly QrcodeDAL qrcodeDAL;

        //Configuracoes do contexto
        public QrCodeController(IESContext context)
        {
            _context = context;
            qrcodeDAL = new QrcodeDAL(context);
        }

        public static int i = 1;
        public async Task<IActionResult> Index()
        {
            await Tempos(i);
            i++;
            return View("Index");
        }

        public async Task<IActionResult> Tempos(int i)
        {
            Timer timer = new Timer();
            timer.Start();

            string data = DateTime.Today.ToString("dd/MM/yyyy");
            data = data + " - " + i + " - valida";
            ViewBag.data = data;

            var qrcode = new Qrcode(1,data);
            await qrcodeDAL.GravarQrcode(qrcode);

            return View("Index");
        }    
    }
}