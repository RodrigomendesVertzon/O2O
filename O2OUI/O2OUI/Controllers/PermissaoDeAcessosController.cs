using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using O2OUI.Models;
using O2OUI.Models.Seguranca;

namespace O2OUI.Controllers
{
    public class PermissaoDeAcessosController : Controller
    {
        private readonly O2OContext _context;

        public PermissaoDeAcessosController(O2OContext context)
        {
            _context = context;
        }

        // GET: PermissaoDeAcessoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.PermissaoDeAcessos.ToListAsync());
        }

        // GET: PermissaoDeAcessoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var permissaoDeAcesso = await _context.PermissaoDeAcessos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (permissaoDeAcesso == null)
            {
                return NotFound();
            }

            return View(permissaoDeAcesso);
        }

        // GET: PermissaoDeAcessoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PermissaoDeAcessoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IpPermitido")] PermissaoDeAcesso permissaoDeAcesso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(permissaoDeAcesso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(permissaoDeAcesso);
        }

        // GET: PermissaoDeAcessoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var permissaoDeAcesso = await _context.PermissaoDeAcessos.FindAsync(id);
            if (permissaoDeAcesso == null)
            {
                return NotFound();
            }
            return View(permissaoDeAcesso);
        }

        // POST: PermissaoDeAcessoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IpPermitido")] PermissaoDeAcesso permissaoDeAcesso)
        {
            if (id != permissaoDeAcesso.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(permissaoDeAcesso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PermissaoDeAcessoExists(permissaoDeAcesso.Id))
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
            return View(permissaoDeAcesso);
        }

        // GET: PermissaoDeAcessoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var permissaoDeAcesso = await _context.PermissaoDeAcessos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (permissaoDeAcesso == null)
            {
                return NotFound();
            }

            return View(permissaoDeAcesso);
        }

        // POST: PermissaoDeAcessoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var permissaoDeAcesso = await _context.PermissaoDeAcessos.FindAsync(id);
            _context.PermissaoDeAcessos.Remove(permissaoDeAcesso);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PermissaoDeAcessoExists(int id)
        {
            return _context.PermissaoDeAcessos.Any(e => e.Id == id);
        }
    }
}
