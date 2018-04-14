using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using ChamadaQrWebAPI.Models;

namespace ChamadaQrWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ChamadaQrController : Controller
    {
        private readonly ChamadaQrContext _context;

        public ChamadaQrController(ChamadaQrContext context)
        {
            _context = context;

            if (_context.Alunos.Count() == 0)
            {
                _context.Alunos.Add(new ALUNO { nome = "Item1" });
                _context.SaveChanges();
            }
        }
    }
}