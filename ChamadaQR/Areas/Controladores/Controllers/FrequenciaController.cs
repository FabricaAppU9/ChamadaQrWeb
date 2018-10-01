using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChamadaQR.Data;
using ChamadaQR.Data.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Modelo.Cadastros;

namespace ChamadaQR.Areas.Controles.Controllers
{
    [Area("Controladores")]
    public class FrequenciaController : Controller
    {
        private readonly IESContext _context;
        private readonly FrequenciaDAL frequenciaDAL;
        private readonly CalendarioDAL calendarioDAL;
        private readonly AlunoDAL alunoDAL;

        //Configuracoes do contexto
        public FrequenciaController(IESContext context)
        {
            _context = context;
            frequenciaDAL = new FrequenciaDAL(context);
            calendarioDAL = new CalendarioDAL(context);
            alunoDAL = new AlunoDAL(context);            
        }

        //VisaoPorID
        private async Task<IActionResult> ObterVisaoFrequenciaPorId(long? id)
        {
            if (id == null)            
                return NotFound();
            
            var frequencia = await frequenciaDAL.ObterFrequenciaPorID((long)id);

            if (frequencia == null)            
                return NotFound();
            
            ViewBag.Calendarios =
                new SelectList(_context.Calendarios.OrderBy(c => c.DataNome), "DataID", "DataNome", frequencia.DataID);

            ValidaPresenca();
            return View(frequencia);
        }
                
        //GET: Frequencia/Index
        public async Task<IActionResult> Index()
        {
            return View(await frequenciaDAL.ObterFrequenciasClassificadasPorNome().ToListAsync());
        }

        //GET: Frequencia/Edit
        public async Task<IActionResult> Edit(long id)
        {
            return await ObterVisaoFrequenciaPorId(id);
        }

        //GET: Frequencia/Details
        public async Task<IActionResult> Details(long? id)
        {
            return await ObterVisaoFrequenciaPorId(id);
        }
        
        //POST: Frequencia/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("FrequenciaID,PresensaID,AlunoID,DataID,Presenca,Justificativa")] Frequencia frequencia)
        {
            if (id != frequencia.FrequenciaID)            
                return NotFound();            

            if (ModelState.IsValid)
            {
                try
                {
                    await frequenciaDAL.AtualizarFrequencia(frequencia);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await FrequenciaExists(frequencia.FrequenciaID))
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
            return View(frequencia);
        }

        //GET: Frequencia/Create
        public IActionResult Create()
        {
            var Alunos = alunoDAL.ObterAlunosClassificadosPorNome().ToList();
            Alunos.Insert(0, new Aluno() { AlunoID = 0, AlunoNome = "Selecione o Aluno" });
            ViewBag.Alunos = Alunos;

            var Calendarios = calendarioDAL.ObterCalendariosClassificadosPorNome().ToList();
            Calendarios.Insert(0, new Calendario() { DataID = 0, DataNome = "Selecione a Data" });
            ViewBag.Calendarios = Calendarios;

            ValidaPresenca();

            return View();
        }

        //POST: Frequencia/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FrequenciaID,AlunoID,DataID,Presenca,Justificativa")] Frequencia frequencia)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await frequenciaDAL.GravarFrequencia(frequencia);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Não foi possível inserir os dados.");
            }
            return View(frequencia);
        }

        //GET: Frequencia/Delete    
        public async Task<IActionResult> Delete(long? id)
        {
            return await ObterVisaoFrequenciaPorId(id);
        }

        //POST: Frequencia/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            var frequencia = await _context.Frequencias.SingleOrDefaultAsync(f => f.FrequenciaID == id);
            _context.Frequencias.Remove(frequencia);
            TempData["Message"] = "A Presenca foi removida";
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //Outros Metodos
        private async Task<bool> FrequenciaExists(long? id)
        {
            return await frequenciaDAL.ObterFrequenciaPorID((long)id) != null;
        }

        private void ValidaPresenca()
        {
            IList<string> p = new List<string>();
            p.Add("S");
            p.Add("N");
            ViewBag.p = p;
        }
    }
}