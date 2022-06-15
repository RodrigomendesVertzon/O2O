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
    public class ConfigurationsController : Controller
    {
        private readonly O2OContext _context;

        public ConfigurationsController(O2OContext context)
        {
            _context = context;
        }

        // GET: Configurations
        public async Task<IActionResult> Index()
        {
            var o2OContext = _context.Configurations.Include(c => c.ConfigLabel);
            return View(await o2OContext.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Index(string txtProcurar)
        {
            if (!String.IsNullOrEmpty(txtProcurar))
                return View(await _context.Configurations.Where(x => x.ConfigLabel.Label.ToUpper().Contains(txtProcurar.ToUpper())).ToListAsync());

            return View(await _context.Configurations.ToListAsync());
        }

        // GET: Configurations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var configuration = await _context.Configurations
                .Include(c => c.ConfigLabel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (configuration == null)
            {
                return NotFound();
            }

            return View(configuration);
        }

        // GET: Configurations/Create
        public IActionResult Create()
        {
            ViewData["IdCL"] = new SelectList(_context.ConfigLabels, "Id", "Label");
            return View();
        }

        // POST: Configurations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdCL,Valores")] Configuration configuration)
        {
            if (ModelState.IsValid)
            {
                _context.Add(configuration);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCL"] = new SelectList(_context.ConfigLabels, "Id", "Label", configuration.IdCL);
            return View(configuration);
        }

        // GET: Configurations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var configuration = await _context.Configurations.FindAsync(id);
            if (configuration == null)
            {
                return NotFound();
            }
            ViewData["IdCL"] = new SelectList(_context.ConfigLabels, "Id", "Label", configuration.IdCL);
            return View(configuration);
        }

        // POST: Configurations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdCL,Valores")] Configuration configuration)
        {
            if (id != configuration.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(configuration);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConfigurationExists(configuration.Id))
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
            ViewData["IdCL"] = new SelectList(_context.ConfigLabels, "Id", "Label", configuration.IdCL);
            return View(configuration);
        }

        // GET: Configurations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var configuration = await _context.Configurations
                .Include(c => c.ConfigLabel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (configuration == null)
            {
                return NotFound();
            }

            return View(configuration);
        }

        // POST: Configurations/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var configuration = await _context.Configurations.FindAsync(id);
            TempData["Confirmacao"] = configuration.Valores + " foi excluído com sucesso!";
            _context.Configurations.Remove(configuration);
            await _context.SaveChangesAsync();
            return Json(configuration.Valores + " excluído com sucesso.");
        }

        private bool ConfigurationExists(int id)
        {
            return _context.Configurations.Any(e => e.Id == id);
        }
    }
}
