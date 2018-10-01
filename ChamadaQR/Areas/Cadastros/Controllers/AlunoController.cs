using ChamadaQR.Data;
using ChamadaQR.Data.DAL;
using Modelo.Cadastros;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ChamadaQR.Areas.Cadastros.Controllers
{
    [Area("Cadastros")]
    public class AlunoController : Controller
    {
        private readonly IESContext _context;
        private readonly AlunoDAL alunoDAL;
        private readonly ProjetoDAL projetoDAL;
        
        //Configuracoes do contexto
        public AlunoController(IESContext context)
        {
            _context = context;
            projetoDAL = new ProjetoDAL(context);
            alunoDAL = new AlunoDAL(context);
        }

        //VisaoPorID
        private async Task<IActionResult> ObterVisaoAlunosPorId(long? id)
        {
            if (id == null)            
                return NotFound();
            
            var aluno = await alunoDAL.ObterAlunoPorId((long)id);

            if (aluno == null)            
                return NotFound();
            
            ViewBag.Projetos =
                new SelectList(_context.Projetos.OrderBy(b => b.ProjetoNome), "ProjetoID", "ProjetoNome", aluno.ProjetoID);

            ValidaStatus();

            return View(aluno);
        }

        //GET: Aluno/Index
        public async Task<IActionResult> Index()
        {
            return View(await alunoDAL.ObterAlunosClassificadosPorNome().ToListAsync());
        }

        //GET: Aluno/Edit    
        public async Task<IActionResult> Edit(long id)
        {
            return await ObterVisaoAlunosPorId(id);
        }

        //GET: Aluno/Details
        public async Task<IActionResult> Details(long? id)
        {
            return await ObterVisaoAlunosPorId(id);
        }
        
        //POST: Aluno/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("AlunoID, AlunoNome, Matricula, ProjetoID, ProjetoNome, Status")] Aluno aluno)
        {
            if (id != aluno.AlunoID)            
                return NotFound();            

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aluno);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlunoExists(aluno.AlunoID))
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
            return View(aluno);
        }

        //GET: Aluno/Create
        public IActionResult Create()
        {
            var Projetos = projetoDAL.ObterProjetosClassificadosPorNome().ToList();

            Projetos.Insert(0, new Projeto() { ProjetoID = 0, ProjetoNome = "Selecione o projeto" });
            ViewBag.Projetos = Projetos;

            ValidaStatus();
            return View();
        }       

        //POST: Aluno/Create       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Matricula, AlunoNome, Status, ProjetoID")] Aluno aluno)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await alunoDAL.GravarAluno(aluno);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Não foi possível inserir os dados.");
            }
            return View(aluno);
        }
       
        //GET: Aluno/Delete
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)            
                return NotFound();            

            var aluno = await _context.Alunos
                .SingleOrDefaultAsync(m => m.AlunoID == id);
            _context.Projetos.Where(i => aluno.ProjetoID == i.ProjetoID).Load(); ;

            if (aluno == null)            
                return NotFound();            

            return View(aluno);
        }

        //POST: Aluno/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            var aluno = await _context.Alunos.SingleOrDefaultAsync(m => m.AlunoID == id);
            _context.Alunos.Remove(aluno);
            TempData["Message"] = "Aluno " + aluno.AlunoNome.ToUpper() + " foi removido";
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //Outros Metodos
        private bool AlunoExists(long? id)
        {
            return _context.Alunos.Any(e => e.AlunoID == id);
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