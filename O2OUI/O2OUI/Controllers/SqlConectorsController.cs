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
    public class SqlConectorsController : Controller
    {
        private readonly O2OContext _context;

        public SqlConectorsController(O2OContext context)
        {
            _context = context;
        }

        // GET: SqlConectors
        public async Task<IActionResult> Index()
        {
            return View(await _context.SqlConectors.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Index(string txtProcurar)
        {
            if (!String.IsNullOrEmpty(txtProcurar))
                return View(await _context.SqlConectors.Where(sql => sql.Identificador.ToUpper().Contains(txtProcurar.ToUpper())).ToListAsync());

            return View(await _context.SqlConectors.ToListAsync());
        }

        // GET: SqlConectors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sqlConector = await _context.SqlConectors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sqlConector == null)
            {
                return NotFound();
            }

            return View(sqlConector);
        }

        // GET: SqlConectors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SqlConectors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Ip,Porta,NomeDoBanco,Usuario,Senha,Identificador,AutenticacaoWindows")] SqlConector sqlConector)
        {
            bool IsIdentificadorExist = _context.SqlConectors.Any
            (x => x.Identificador == sqlConector.Identificador && x.Id != sqlConector.Id);
            if (IsIdentificadorExist == true)
            {
                ModelState.AddModelError("Identificador", "Identificador já existe");
            }

            if (ModelState.IsValid)
            {
                TempData["Confirmacao"] = sqlConector.Identificador + " foi criado com sucesso!";

                _context.Add(sqlConector);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sqlConector);
        }

        // GET: SqlConectors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sqlConector = await _context.SqlConectors.FindAsync(id);
            if (sqlConector == null)
            {
                return NotFound();
            }
            return View(sqlConector);
        }

        // POST: SqlConectors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Ip,Porta,NomeDoBanco,Usuario,Senha,Identificador,AutenticacaoWindows")] SqlConector sqlConector)
        {
            if (id != sqlConector.Id)
            {
                return NotFound();
            }

            bool IsIdentificadorExist = _context.SqlConectors.Any
            (x => x.Identificador == sqlConector.Identificador && x.Id != sqlConector.Id);
            if (IsIdentificadorExist == true)
            {
                ModelState.AddModelError("Identificador", "Identificador já existe");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    TempData["Confirmacao"] = sqlConector.Identificador + " foi alterado com sucesso!";


                    _context.Update(sqlConector);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SqlConectorExists(sqlConector.Id))
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
            return View(sqlConector);
        }

        // GET: SqlConectors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sqlConector = await _context.SqlConectors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sqlConector == null)
            {
                return NotFound();
            }

            return View(sqlConector);
        }

        // POST: SqlConectors/Delete/5
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var sqlConector = await _context.SqlConectors.FindAsync(id);
            TempData["Confirmacao"] = sqlConector.Identificador + " foi excluído com sucesso!";
            _context.SqlConectors.Remove(sqlConector);
            await _context.SaveChangesAsync();
            return Json(sqlConector.Identificador + " excluído com sucesso.");
        }

        private bool SqlConectorExists(int id)
        {
            return _context.SqlConectors.Any(e => e.Id == id);
        }
    }
}
