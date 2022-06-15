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
    public class CheckLicensesController : Controller
    {
        private readonly O2OContext _context;

        public CheckLicensesController(O2OContext context)
        {
            _context = context;
        }

        // GET: CheckLicenses
        public async Task<IActionResult> Index()
        {
            return View(await _context.CheckLicenses.ToListAsync());
        }

        // GET: CheckLicenses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checkLicense = await _context.CheckLicenses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (checkLicense == null)
            {
                return NotFound();
            }

            return View(checkLicense);
        }

        // GET: CheckLicenses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CheckLicenses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DataDeChecagem")] CheckLicense checkLicense)
        {
            if (ModelState.IsValid)
            {
                _context.Add(checkLicense);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(checkLicense);
        }

        // GET: CheckLicenses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checkLicense = await _context.CheckLicenses.FindAsync(id);
            if (checkLicense == null)
            {
                return NotFound();
            }
            return View(checkLicense);
        }

        // POST: CheckLicenses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DataDeChecagem")] CheckLicense checkLicense)
        {
            if (id != checkLicense.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(checkLicense);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CheckLicenseExists(checkLicense.Id))
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
            return View(checkLicense);
        }

        // GET: CheckLicenses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checkLicense = await _context.CheckLicenses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (checkLicense == null)
            {
                return NotFound();
            }

            return View(checkLicense);
        }

        // POST: CheckLicenses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var checkLicense = await _context.CheckLicenses.FindAsync(id);
            _context.CheckLicenses.Remove(checkLicense);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CheckLicenseExists(int id)
        {
            return _context.CheckLicenses.Any(e => e.Id == id);
        }
    }
}
