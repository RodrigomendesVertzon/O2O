using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using O2OUI.Models;

namespace O2OUI.Controllers
{
    public class ExcelConectorsController : Controller
    {
        private readonly O2OContext _context;

        public ExcelConectorsController(O2OContext context)
        {
            _context = context;
        }

        // GET: ExcelConectors
        public async Task<IActionResult> Index()
        {
            return View(await _context.ExcelConectors.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Index(string txtProcurar)
        {
            if (!String.IsNullOrEmpty(txtProcurar))
                return View(await _context.ExcelConectors.Where(x => x.Identificador.ToUpper().Contains(txtProcurar.ToUpper())).ToListAsync());

            return View(await _context.ExcelConectors.ToListAsync());
        }


        // GET: ExcelConectors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var excelConector = await _context.ExcelConectors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (excelConector == null)
            {
                return NotFound();
            }

            return View(excelConector);
        }

        // GET: ExcelConectors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ExcelConectors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Ip,DiretorioCompartilhado,NomeArquivo,Sheet,Usuario,Senha,Identificador")] ExcelConector excelConector)
        {
            bool IsIdentificadorExist = _context.MySqlConectors.Any
            (x => x.Identificador == excelConector.Identificador && x.Id != excelConector.Id);
            if (IsIdentificadorExist == true)
            {
                ModelState.AddModelError("Identificador", "Identificador já existe");
            }

            if (ModelState.IsValid)
            {
                TempData["Confirmacao"] = excelConector.Identificador + " foi criado com sucesso!"; 
                _context.Add(excelConector);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(excelConector);
        }

        // GET: ExcelConectors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var excelConector = await _context.ExcelConectors.FindAsync(id);
            if (excelConector == null)
            {
                return NotFound();
            }
            return View(excelConector);
        }

        // POST: ExcelConectors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Ip,DiretorioCompartilhado,NomeArquivo,Sheet,Usuario,Senha,Identificador")] ExcelConector excelConector)
        {
            if (id != excelConector.Id)
            {
                return NotFound();
            }

            bool IsIdentificadorExist = _context.MySqlConectors.Any
            (x => x.Identificador == excelConector.Identificador && x.Id != excelConector.Id);
            if (IsIdentificadorExist == true)
            {
                ModelState.AddModelError("Identificador", "Identificador já existe");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    TempData["Confirmacao"] = excelConector.Identificador + " foi alterado com sucesso!";


                    _context.Update(excelConector);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExcelConectorExists(excelConector.Id))
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
            return View(excelConector);
        }

        // GET: ExcelConectors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var excelConector = await _context.ExcelConectors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (excelConector == null)
            {
                return NotFound();
            }

            return View(excelConector);
        }

        // POST: ExcelConectors/Delete/5
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var excelConector = await _context.ExcelConectors.FindAsync(id);
            TempData["Confirmacao"] = excelConector.Identificador + " foi excluído com sucesso!";
            _context.ExcelConectors.Remove(excelConector);
            await _context.SaveChangesAsync();
            return Json(excelConector.Identificador + " excluído com sucesso.");
        }

        private bool ExcelConectorExists(int id)
        {
            return _context.ExcelConectors.Any(e => e.Id == id);
        }
    }
}
