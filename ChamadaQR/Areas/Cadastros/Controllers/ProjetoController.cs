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
    public class ProjetoController : Controller
    {
        private readonly IESContext _context;
        private readonly ProjetoDAL projetoDAL;

        //Configuracoes do contexto
        public ProjetoController(IESContext context)
        {
            _context = context;
            projetoDAL = new ProjetoDAL(context);
        }

        //VisaoPorID
        private async Task<IActionResult> ObterVisaoProjetoPorId(long? id)
        {
            if (id == null)            
                return NotFound();
            
            var projeto = await projetoDAL.ObterProjetoPorId((long)id);

            if (projeto == null)            
                return NotFound();
            
            return View(projeto);
        }

        //GET: Projeto/Index
        public async Task<IActionResult> Index()
        {
            return View(await projetoDAL.ObterProjetosClassificadosPorNome().ToListAsync());
        }       

        //GET: Projeto/Edit
        public async Task<IActionResult> Edit(long id)
        {
            return await ObterVisaoProjetoPorId(id);
        }

        //GET: Projeto/Details
        public async Task<IActionResult> Details(long? id)
        {
            return await ObterVisaoProjetoPorId(id);
        }
        
        //POST: Projeto/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("ProjetoID,ProjetoNome,Endereco")] Projeto projeto)
        {
            if (id != projeto.ProjetoID)            
                return NotFound();            

            if (ModelState.IsValid)
            {
                try
                {
                    await projetoDAL.GravarProjeto(projeto);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await ProjetoExists(projeto.ProjetoID))
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
            return View(projeto);
        }

        //GET: Projeto/Create
        public IActionResult Create()
        {
            return View();
        }

        //POST: Projeto/Create        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProjetoNome,Endereco")] Projeto projeto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await projetoDAL.GravarProjeto(projeto);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Não foi possível inserir os dados.");
            }
            return View(projeto);
        }

        //GET: Projeto/Delete
        public async Task<IActionResult> Delete(long? id)
        {
            return await ObterVisaoProjetoPorId(id);
        }
              
        //POST: Projeto/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            var projeto = await projetoDAL.EliminaProjetoPorId((long)id);
            TempData["Message"] = "Projeto " + projeto.ProjetoNome.ToUpper() + " foi removida";
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //Outros Metodos
        private async Task<bool> ProjetoExists(long? id)
        {
            return await projetoDAL.ObterProjetoPorId((long)id) != null;
        }
    }
}
