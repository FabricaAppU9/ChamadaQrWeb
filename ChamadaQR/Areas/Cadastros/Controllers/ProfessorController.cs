using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChamadaQR.Data;
using ChamadaQR.Data.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Modelo.Cadastros;

namespace ChamadaQR.Areas.Cadastros.Controllers
{
    [Area("Cadastros")]
    public class ProfessorController : Controller
    {
        private readonly IESContext _context;
        private readonly ProfessorDAL professorDAL;
        private readonly ProjetoDAL projetoDAL;

        //Configuracoes do contexto
        public ProfessorController(IESContext context)
        {
            this._context = context;
            projetoDAL = new ProjetoDAL(context);
            professorDAL = new ProfessorDAL(context);
        }

        //VisaoPorID
        private async Task<IActionResult> ObterVisaoProfessorPorId(long? id)
        {
            if (id == null)            
                return NotFound();
            
            var professor = await professorDAL.ObterProfessorPorId((long)id);

            if (professor == null)            
                return NotFound();

            ViewBag.Projetos = 
                new SelectList(_context.Projetos.OrderBy(b => b.ProjetoNome), "ProjetoID", "ProjetoNome", professor.ProjetoID);

            ValidaStatus();

            return View(professor);
        }

        //GET: Professor/Index
        public async Task<IActionResult> Index()
        {
            return View(await professorDAL.ObterProfessoresClassificadosPorNome().ToListAsync());
        }

        //GET: Professor/Details
        public async Task<IActionResult> Details(long? id)
        {
            return await ObterVisaoProfessorPorId(id);
        }

        //GET: Professor/Edit
        public async Task<IActionResult> Edit(long id)
        {
            return await ObterVisaoProfessorPorId(id);
        }

        //POST: Professor/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("ProfessorID, ProfessorNome, Matricula, ProjetoID, ProjetoNome, Status")] Professor professor)
        {
            if (id != professor.ProfessorID)            
                return NotFound();          

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(professor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfessorExists(professor.ProfessorID))
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
            return View(professor);
        }

        //GET: Professor/Create
        public IActionResult Create()
        {
            var Projetos = projetoDAL.ObterProjetosClassificadosPorNome().ToList();
            Projetos.Insert(0, new Projeto() { ProjetoID = 0, ProjetoNome = "Selecione o projeto" });
            ViewBag.Projetos = Projetos;

            ValidaStatus();
            return View();
        }       

        //POST: Professor/Create       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Matricula, ProfessorNome, Status, ProjetoID")] Professor professor)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await professorDAL.GravarProfessor(professor);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Não foi possível inserir os dados.");
            }
            return View(professor);
        }

        //GET: Professor/Delete
        public async Task<IActionResult> Delete(long? id)
        {
            return await ObterVisaoProfessorPorId(id);           
        }

        //POST: Professor/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            var professor = await _context.Professores.SingleOrDefaultAsync(m => m.ProfessorID == id);
            _context.Professores.Remove(professor);
            TempData["Message"] = "Professor " + professor.ProfessorNome.ToUpper() + " foi removido";
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //Outros Metodos
        private bool ProfessorExists(long? id)
        {
            return _context.Professores.Any(p => p.ProfessorID == id);
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