using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ChamadaQR.Data;
using Modelo.Cadastros;
using ChamadaQR.Data.DAL;
using Microsoft.AspNetCore.Authorization;

namespace ChamadaQR.Areas.Cadastros.Controllers
{
    [Area("Cadastros")]
    [Authorize]
    public class UnidadeController : Controller
    {
        private readonly IESContext _context;
        private readonly UnidadeDAL unidadeDAL;

        //Configuracoes do contexto
        public UnidadeController(IESContext context)
        {
            _context = context;
            unidadeDAL = new UnidadeDAL(context);
        }

        //VisaoPorID
        private async Task<IActionResult> ObterVisaoUnidadePorId(long? id)
        {
            if (id == null)            
                return NotFound();
            
            var unidade = await unidadeDAL.ObterUnidadePorId((long)id);

            if (unidade == null)            
                return NotFound();

            //ViewBag.Unidades =
            //   new SelectList(_context.Unidades.OrderBy(u => u.UnidadeNome), "UnidadeID", "UnidadeNome", unidade.UnidadeID);

            ValidaStatus();

            return View(unidade);
        }

        //GET: Unidade/Index
        public async Task<IActionResult> Index()
        {
            return View(await unidadeDAL.ObterUnidadesClassificadosPorNome().ToListAsync());
        }

        //GET: Unidade/Edit
        public async Task<IActionResult> Edit(long id)
        {
            return await ObterVisaoUnidadePorId(id);
        }

        //GET: Unidade/Details
        public async Task<IActionResult> Details(long? id)
        {
            return await ObterVisaoUnidadePorId(id);
        }
        
        //POST: Unidade/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("UnidadeID,UnidadeNome,Alias,Status")] Unidade unidade)
        {
            if (id != unidade.UnidadeID)            
                return NotFound();            

            if (ModelState.IsValid)
            {
                try
                {
                    await unidadeDAL.GravarUnidade(unidade);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await UnidadeExists(unidade.UnidadeID))
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
            return View(unidade);
        }

        //GET: Unidade/Create
        public IActionResult Create()
        {
            ValidaStatus();
            return View();
        }

        //POST: Unidade/Create        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UnidadeNome,Alias,Status")] Unidade unidade)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await unidadeDAL.GravarUnidade(unidade);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Não foi possível inserir os dados.");
            }
            return View(unidade);
        }

        //GET: Unidade/Delete
        public async Task<IActionResult> Delete(long? id)
        {
            return await ObterVisaoUnidadePorId(id);
        }
              
        //POST: Unidade/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            var unidade = await unidadeDAL.EliminaUnidadePorId((long)id);
            TempData["Message"] = "Unidade " + unidade.UnidadeNome.ToUpper() + " foi removida";
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //Outros Metodos
        private async Task<bool> UnidadeExists(long? id)
        {
            return await unidadeDAL.ObterUnidadePorId((long)id) != null;
        }

        private void ValidaStatus()
        {
            IList<string> s = new List<string>();
            s.Add("ATIVO");
            s.Add("INATIVO");
            ViewBag.s = s;
        }
    }
}
