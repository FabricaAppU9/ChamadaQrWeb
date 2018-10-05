using System;
using System.Threading.Tasks;
using System.Timers;

using Microsoft.AspNetCore.Mvc;

namespace ChamadaQC.Controllers
{
    //https://www.youtube.com/watch?v=zKygdgTRGY4&t=274s

    public class QrCodeController : Controller
    {
        public static int i = 1;
        public IActionResult Index()
        {
            Tempos(i);
            i++;
            return View("Index");
        }

        public IActionResult Tempos(int i)
        {
            Timer timer = new Timer();           
            timer.Start();

            string data = DateTime.Today.ToString("dd/MM/yyyy");
            ViewBag.data = data + " - " + i + " - valida";

            return View("Index");
        }


        //public IActionResult Generate()
        //{
        //    string senha = "@teste";
        //    string data = DateTime.Today.ToString("dd/MM/yyyy");
        //    string dataComposta = data + ";" + senha;
        //    ViewBag.data = dataComposta.GetHashCode();

        //    Timer timer = new Timer(1000);
        //    timer.Elapsed += async (sender, e) => await HandleTimer();
        //    timer.Start();

        //    ViewBag.data = i;
        //    i++;
        //    return View("Index");
        //}
        //private static Task HandleTimer()
        //{
        //    throw new NotImplementedException();
        //}
    }
}