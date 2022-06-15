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
    public class OracleConectorsController : Controller
    {
        private readonly O2OContext _context;

        public OracleConectorsController(O2OContext context)
        {
            _context = context;
        }

        // GET: OracleConectors
        public async Task<IActionResult> Index()
        {
            return View(await _context.OracleConector.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Index(string txtProcurar)
        {
            if (!String.IsNullOrEmpty(txtProcurar))
                return View(await _context.OracleConectors.Where(o => o.Identificador.ToUpper().Contains(txtProcurar.ToUpper())).ToListAsync());

            return View(await _context.OracleConectors.ToListAsync());
        }

        // GET: OracleConectors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oracleConector = await _context.OracleConector
                .FirstOrDefaultAsync(m => m.Id == id);
            if (oracleConector == null)
            {
                return NotFound();
            }

            return View(oracleConector);
        }

        // GET: OracleConectors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OracleConectors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Ip,Porta,NomeDoBanco,Usuario,Senha,Identificador,ServicesName")] OracleConector oracleConector)
        {

            bool IsIdentificadorExist = _context.OracleConectors.Any
            (x => x.Identificador == oracleConector.Identificador && x.Id != oracleConector.Id);
            if (IsIdentificadorExist == true)
            {
                ModelState.AddModelError("Identificador", "Identificador já existe");
            }

            if (ModelState.IsValid)
            {
                TempData["Confirmacao"] = oracleConector.Identificador + " foi criado com sucesso!";


                _context.Add(oracleConector);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(oracleConector);
        }

        // GET: OracleConectors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oracleConector = await _context.OracleConector.FindAsync(id);
            if (oracleConector == null)
            {
                return NotFound();
            }
            return View(oracleConector);
        }

        // POST: OracleConectors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Ip,Porta,NomeDoBanco,Usuario,Senha,Identificador,ServicesName")] OracleConector oracleConector)
        {
            if (id != oracleConector.Id)
            {
                return NotFound();
            }

            bool IsIdentificadorExist = _context.OracleConectors.Any
            (x => x.Identificador == oracleConector.Identificador && x.Id != oracleConector.Id);
            if (IsIdentificadorExist == true)
            {
                ModelState.AddModelError("Identificador", "Identificador já existe");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    TempData["Confirmacao"] = oracleConector.Identificador + " foi alterado com sucesso!";


                    _context.Update(oracleConector);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OracleConectorExists(oracleConector.Id))
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
            return View(oracleConector);
        }

        // GET: OracleConectors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oracleConector = await _context.OracleConector
                .FirstOrDefaultAsync(m => m.Id == id);
            if (oracleConector == null)
            {
                return NotFound();
            }

            return View(oracleConector);
        }

        // POST: OracleConectors/Delete/5
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var oracleConector = await _context.OracleConector.FindAsync(id);
            TempData["Confirmacao"] = oracleConector.Identificador + " foi excluído com sucesso!";
            _context.OracleConector.Remove(oracleConector);
            await _context.SaveChangesAsync();
            return Json(oracleConector.Identificador + " excluído com sucesso.");
        }

        private bool OracleConectorExists(int id)
        {
            return _context.OracleConector.Any(e => e.Id == id);
        }
    }
}
