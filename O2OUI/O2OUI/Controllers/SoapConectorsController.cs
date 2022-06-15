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
    public class SoapConectorsController : Controller
    {
        private readonly O2OContext _context;

        public SoapConectorsController(O2OContext context)
        {
            _context = context;
        }

        // GET: SoapConectors
        public async Task<IActionResult> Index()
        {
            return View(await _context.SoapConectors.ToListAsync());
        }
        [HttpPost]
        public async Task<IActionResult> Index(string txtProcurar)
        {
            if (!String.IsNullOrEmpty(txtProcurar))
                return View(await _context.SoapConectors.Where(x => x.Identificador.ToUpper().Contains(txtProcurar.ToUpper())).ToListAsync());

            return View(await _context.SoapConectors.ToListAsync());
        }
        // GET: SoapConectors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var soapConector = await _context.SoapConectors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (soapConector == null)
            {
                return NotFound();
            }

            return View(soapConector);
        }

        // GET: SoapConectors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SoapConectors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Url,Usuario,Senha,Identificador,TipoDeAutenticacao")] SoapConector soapConector)
        {
            bool IsIdentificadorExist = _context.SoapConectors.Any
            (x => x.Identificador == soapConector.Identificador && x.Id != soapConector.Id);
            if (IsIdentificadorExist == true)
            {
                ModelState.AddModelError("Identificador", "Identificador já existe");
            }

            if (ModelState.IsValid)
            {
                TempData["Confirmacao"] = soapConector.Identificador + " foi criado com sucesso!";


                _context.Add(soapConector);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(soapConector);
        }

        // GET: SoapConectors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var soapConector = await _context.SoapConectors.FindAsync(id);
            if (soapConector == null)
            {
                return NotFound();
            }
            return View(soapConector);
        }

        // POST: SoapConectors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Url,Usuario,Senha,Identificador,TipoDeAutenticacao")] SoapConector soapConector)
        {
            if (id != soapConector.Id)
            {
                return NotFound();
            }

            bool IsIdentificadorExist = _context.SoapConectors.Any
            (x => x.Identificador == soapConector.Identificador && x.Id != soapConector.Id);
            if (IsIdentificadorExist == true)
            {
                ModelState.AddModelError("Identificador", "Identificador já existe");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    TempData["Confirmacao"] = soapConector.Identificador + " foi alterado com sucesso!";


                    _context.Update(soapConector);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SoapConectorExists(soapConector.Id))
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
            return View(soapConector);
        }

        // GET: SoapConectors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var soapConector = await _context.SoapConectors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (soapConector == null)
            {
                return NotFound();
            }

            return View(soapConector);
        }

        // POST: SoapConectors/Delete/5
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var soapConector = await _context.SoapConectors.FindAsync(id);
            TempData["Confirmacao"] = soapConector.Identificador + " foi excluído com sucesso!";
            _context.SoapConectors.Remove(soapConector);
            await _context.SaveChangesAsync();
            return Json(soapConector.Identificador + " excluído com sucesso.");
        }

        private bool SoapConectorExists(int id)
        {
            return _context.SoapConectors.Any(e => e.Id == id);
        }
    }
}
