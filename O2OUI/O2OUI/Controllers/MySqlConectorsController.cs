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
    public class MySqlConectorsController : Controller
    {
        private readonly O2OContext _context;

        public MySqlConectorsController(O2OContext context)
        {
            _context = context;
        }

        // GET: MySqlConectors
        public async Task<IActionResult> Index()
        {
            return View(await _context.MySqlConector.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Index(string txtProcurar)
        {
            if (!String.IsNullOrEmpty(txtProcurar))
                return View(await _context.MySqlConectors.Where(msql => msql.Identificador.ToUpper().Contains(txtProcurar.ToUpper())).ToListAsync());

            return View(await _context.MySqlConectors.ToListAsync());
        }

        // GET: MySqlConectors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mySqlConector = await _context.MySqlConector
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mySqlConector == null)
            {
                return NotFound();
            }

            return View(mySqlConector);
        }

        // GET: MySqlConectors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MySqlConectors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Ip,Porta,NomeDoBanco,Usuario,Senha,Identificador")] MySqlConector mySqlConector)
        {
            bool IsIdentificadorExist = _context.MySqlConectors.Any
            (x => x.Identificador == mySqlConector.Identificador && x.Id != mySqlConector.Id);
            if (IsIdentificadorExist == true)
            {
                ModelState.AddModelError("Identificador", "Identificador já existe");
            }

            if (ModelState.IsValid)
            {
                TempData["Confirmacao"] = mySqlConector.Identificador + " foi criado com sucesso!";


                _context.Add(mySqlConector);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mySqlConector);
        }

        // GET: MySqlConectors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mySqlConector = await _context.MySqlConector.FindAsync(id);
            if (mySqlConector == null)
            {
                return NotFound();
            }
            return View(mySqlConector);
        }

        // POST: MySqlConectors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Ip,Porta,NomeDoBanco,Usuario,Senha,Identificador")] MySqlConector mySqlConector)
        {
            if (id != mySqlConector.Id)
            {
                return NotFound();
            }

            bool IsIdentificadorExist = _context.MySqlConectors.Any
            (x => x.Identificador == mySqlConector.Identificador && x.Id != mySqlConector.Id);
            if (IsIdentificadorExist == true)
            {
                ModelState.AddModelError("Identificador", "Identificador já existe");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    TempData["Confirmacao"] = mySqlConector.Identificador + " foi alterado com sucesso!";


                    _context.Update(mySqlConector);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MySqlConectorExists(mySqlConector.Id))
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
            return View(mySqlConector);
        }

        // GET: MySqlConectors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mySqlConector = await _context.MySqlConector
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mySqlConector == null)
            {
                return NotFound();
            }

            return View(mySqlConector);
        }

        // POST: MySqlConectors/Delete/5
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var mySqlConector = await _context.MySqlConector.FindAsync(id);
            TempData["Confirmacao"] = mySqlConector.Identificador + " foi excluído com sucesso!";
            _context.MySqlConector.Remove(mySqlConector);
            await _context.SaveChangesAsync();
            return Json(mySqlConector.Identificador + " excluído com sucesso.");
        }

        private bool MySqlConectorExists(int id)
        {
            return _context.MySqlConector.Any(e => e.Id == id);
        }
    }
}
