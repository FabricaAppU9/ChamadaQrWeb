using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChamadaQR.Data;
using ChamadaQR.Data.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Modelo.Cadastros;

namespace ChamadaQR.Areas.Cadastros.Controllers
{
    [Area("Cadastros")]
    [Authorize]
    public class CalendarioController : Controller
    {
        private readonly IESContext _context;
        private readonly CalendarioDAL calendarioDAL;

        //Configuracoes do contexto
        public CalendarioController(IESContext context)
        {
            _context = context;
            calendarioDAL = new CalendarioDAL(context);
        }

        //VisaoPorID
        private async Task<IActionResult> ObterVisaoCalendarioPorId(long? id)
        {
            if (id == null)            
                return NotFound();            

            var calendario = await calendarioDAL.ObterCalendarioPorId((long)id);

            if (calendario == null)            
                return NotFound();            

            return View(calendario);
        }

        //GET: Calendario/Index
        public async Task<IActionResult> Index()
        {
            return View(await calendarioDAL.ObterCalendariosClassificadosPorNome().ToListAsync());
        }

        //GET: Calendario/Details
        public async Task<IActionResult> Details(long? id)
        {
            return await ObterVisaoCalendarioPorId(id);
        }
       
        //GET: Calendario/Edit
        public async Task<IActionResult> Edit(long id)
        {
            return await ObterVisaoCalendarioPorId(id);
        }

        //POST: Calendario/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("DataID,DataNome")] Calendario calendario)
        {
            if (id != calendario.DataID)            
                return NotFound();            

            if (ModelState.IsValid)
            {
                try
                {
                    await calendarioDAL.GravarCalendario(calendario);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await CalendarioExists(calendario.DataID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(calendario);
        }

        //GET: Calendario/Create
        public IActionResult Create()
        {
            return View();
        }

        //POST: Calendario/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DataNome")] Calendario calendario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await calendarioDAL.GravarCalendario(calendario);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Não foi possível inserir os dados.");
            }
            return View(calendario);
        }

        //GET: Calendario/Delete
        public async Task<IActionResult> Delete(long? id)
        {
            return await ObterVisaoCalendarioPorId(id);
        }

        //POST: Calendario/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            var calendario = await calendarioDAL.EliminarCalendarioPorId((long)id);
            TempData["Message"] = "A Data " + calendario.DataNome.ToUpper() + " foi removida";
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //Outros Metodos
        private async Task<bool> CalendarioExists(long? id)
        {
            return await calendarioDAL.ObterCalendarioPorId((long)id) != null;
        }
    }
}