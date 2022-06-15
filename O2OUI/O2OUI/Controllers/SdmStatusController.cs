using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using O2OUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace O2OUI.Controllers
{
    public class SdmStatusController : Controller
    {
        private readonly O2OContext _context;

        public SdmStatusController(O2OContext context)
        {
            _context = context;
        }

        // GET: SdmStatus
        public async Task<IActionResult> Index()
        {
            var o2OContext = _context.SdmStatus.Include(s => s.SdmConector);
            return View(await o2OContext.ToListAsync());
        }


        [HttpPost]
        public async Task<IActionResult> Index(string txtProcurar)
        {
            if (!String.IsNullOrEmpty(txtProcurar))
                return View(await _context.SdmStatus.Where(x => x.SdmConector.Nome.ToUpper().Contains(txtProcurar.ToUpper())).ToListAsync());

            return View(await _context.SdmStatus.ToListAsync());
        }

        // GET: SdmStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sdmStatus = await _context.SdmStatus
                .Include(s => s.SdmConector)
                .FirstOrDefaultAsync(m => m.SdmConector.Id == id);
            if (sdmStatus == null)
            {
                return NotFound();
            }

            return View(sdmStatus);
        }

        // GET: SdmStatus/Create
        public IActionResult Create()
        {
            ViewData["IdSdm"] = new SelectList(_context.SdmConectors, "Id", "Identificador");
            return View();
        }

        // POST: SdmStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdSdm,Status,StatusType")] SdmStatus sdmStatus)
        {
            if (ModelState.IsValid)
            {

                TempData["Confirmacao"] = sdmStatus.Id + " foi criado com sucesso!";

                _context.Add(sdmStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdSdm"] = new SelectList(_context.SdmConectors, "Id", "Identificador", sdmStatus.IdSdm);
            return View(sdmStatus);
        }

        // GET: SdmStatus/Create
        public IActionResult CreateD()
        {
            string sdmNome = TempData["SdmNome"].ToString();
            ViewData["IdSdm"] = new SelectList(_context.SdmConectors.Where(x => x.Identificador == sdmNome), "Id", "Identificador");
            return View();
        }

        // POST: SdmStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateD([Bind("Id,IdSdm,Status,StatusType")] SdmStatus sdmStatus)
        {
              if (ModelState.IsValid)
            {

                TempData["Confirmacao"] = sdmStatus.Id + " foi criado com sucesso!";
                string returnPage = TempData["SdmId"].ToString();
                _context.Add(sdmStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "SdmConectors", new { id = returnPage });
            }
            ViewData["IdSdm"] = new SelectList(_context.SdmConectors, "Id", "Identificador", sdmStatus.IdSdm);
            return View(sdmStatus);
        }

        // GET: SdmStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sdmStatus = await _context.SdmStatus.FindAsync(id);
            if (sdmStatus == null)
            {
                return NotFound();
            }

            ViewData["IdSdm"] = new SelectList(_context.SdmConectors, "Id", "Identificador", sdmStatus.IdSdm);
            return View(sdmStatus);
        }

        // POST: SdmStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdSdm,Status,StatusType")] SdmStatus sdmStatus)
        {
            if (id != sdmStatus.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    TempData["Confirmacao"] = sdmStatus.Id + " foi alterado com sucesso!";

                    _context.Update(sdmStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SdmStatusExists(sdmStatus.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                string returnPage = TempData["SdmId"].ToString();
                return RedirectToAction("Details", "SdmConectors", new { id = returnPage });
            }
            ViewData["IdSdm"] = new SelectList(_context.SdmConectors, "Id", "Identificador", sdmStatus.IdSdm);
            return View(sdmStatus);
        }

        // GET: SdmStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sdmStatus = await _context.SdmStatus
                .Include(s => s.SdmConector)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sdmStatus == null)
            {
                return NotFound();
            }

            return View(sdmStatus);
        }

        // POST: SdmStatus1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sdmStatus = await _context.SdmStatus.FindAsync(id);
            _context.SdmStatus.Remove(sdmStatus);
            await _context.SaveChangesAsync();
            string returnPage = TempData["SdmId"].ToString();
            return RedirectToAction("Details", "SdmConectors", new { id = returnPage });
        }

        private bool SdmStatusExists(int id)
        {
            return _context.SdmStatus.Any(e => e.Id == id);
        }
    }
}