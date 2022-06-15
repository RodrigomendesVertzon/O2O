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
    public class SNowConectorsController : Controller
    {
        private readonly O2OContext _context;

        public SNowConectorsController(O2OContext context)
        {
            _context = context;
        }

        // GET: SNowConectors
        public async Task<IActionResult> Index()
        {
            return View(await _context.SNowConectors.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Index(string txtProcurar)
        {
            if (!String.IsNullOrEmpty(txtProcurar))
                return View(await _context.SNowConectors.Where(x => x.Identificador.ToUpper().Contains(txtProcurar.ToUpper())).ToListAsync());

            return View(await _context.SNowConectors.ToListAsync());
        }
        // GET: SNowConectors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sNowConector = await _context.SNowConectors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sNowConector == null)
            {
                return NotFound();
            }

            return View(sNowConector);
        }

        // GET: SNowConectors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SNowConectors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Url,Usuario,Senha,Identificador")] SNowConector sNowConector)
        {
            bool IsIdentificadorExist = _context.SNowConectors.Any
            (x => x.Identificador == sNowConector.Identificador && x.Id != sNowConector.Id);
            if (IsIdentificadorExist == true)
            {
                ModelState.AddModelError("Identificador", "Identificador já existe");
            }

            if (ModelState.IsValid)
            {
                TempData["Confirmacao"] = sNowConector.Nome + " foi criado com sucesso!";


                _context.Add(sNowConector);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sNowConector);
        }

        // GET: SNowConectors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sNowConector = await _context.SNowConectors.FindAsync(id);
            if (sNowConector == null)
            {
                return NotFound();
            }
            return View(sNowConector);
        }

        // POST: SNowConectors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Url,Usuario,Senha,Identificador")] SNowConector sNowConector)
        {
            if (id != sNowConector.Id)
            {
                return NotFound();
            }

            bool IsIdentificadorExist = _context.SNowConectors.Any
            (x => x.Identificador == sNowConector.Identificador && x.Id != sNowConector.Id);
            if (IsIdentificadorExist == true)
            {
                ModelState.AddModelError("Identificador", "Identificador já existe");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    TempData["Confirmacao"] = sNowConector.Nome + " foi alterado com sucesso!";


                    _context.Update(sNowConector);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SNowConectorExists(sNowConector.Id))
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
            return View(sNowConector);
        }

        // GET: SNowConectors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sNowConector = await _context.SNowConectors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sNowConector == null)
            {
                return NotFound();
            }

            return View(sNowConector);
        }

        // POST: SNowConectors/Delete/5
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var sNowConector = await _context.SNowConector.FindAsync(id);
            TempData["Confirmacao"] = sNowConector.Nome + " foi excluído com sucesso!";
            _context.SNowConectors.Remove(sNowConector);
            await _context.SaveChangesAsync();
            return Json(sNowConector.Nome + " excluído com sucesso.");
        }

        private bool SNowConectorExists(int id)
        {
            return _context.SNowConector.Any(e => e.Id == id);
        }
    }
}
