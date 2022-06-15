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
    public class SdmConectorsController : Controller
    {
        private readonly O2OContext _context;

        public SdmConectorsController(O2OContext context)
        {
            _context = context;
        }

        // GET: SdmConectors
        public async Task<IActionResult> Index()
        {
            return View(await _context.SdmConectors.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Index(string txtProcurar)
        {
            if (!String.IsNullOrEmpty(txtProcurar))
                return View(await _context.SdmConectors.Where(x => x.Identificador.ToUpper().Contains(txtProcurar.ToUpper())).ToListAsync());

            return View(await _context.SdmConectors.ToListAsync());
        }

        // GET: SdmConectors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SdmViewModel model = new SdmViewModel();
            model.SdmConector = await _context.SdmConectors
                .FirstOrDefaultAsync(m => m.Id == id);
            model.SdmStatus = _context.SdmStatus.ToList().Where(m => m.IdSdm == id);
            TempData["SdmNome"] = model.SdmConector.Identificador;
            TempData["SdmId"] = model.SdmConector.Id;
            if (model.SdmConector == null)
            {
                return NotFound();
            }

            return View(model);
        }

        // GET: SdmConectors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SdmConectors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Url,Usuario,Senha,Identificador")] SdmConector sdmConector)
        {
            bool IsIdentificadorExist = _context.SdmConectors.Any
            (x => x.Identificador == sdmConector.Identificador && x.Id != sdmConector.Id);
            if (IsIdentificadorExist == true)
            {
                ModelState.AddModelError("Identificador", "Identificador já existe");
            }

            if (ModelState.IsValid)
            {
                TempData["Confirmacao"] = sdmConector.Identificador + " foi criado com sucesso!";

                _context.Add(sdmConector);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sdmConector);
        }

        // GET: SdmConectors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sdmConector = await _context.SdmConectors.FindAsync(id);
            if (sdmConector == null)
            {
                return NotFound();
            }
            return View(sdmConector);
        }

        // POST: SdmConectors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Url,Usuario,Senha,Identificador")] SdmConector sdmConector)
        {
            if (id != sdmConector.Id)
            {
                return NotFound();
            }

            bool IsIdentificadorExist = _context.SdmConectors.Any
            (x => x.Identificador == sdmConector.Identificador && x.Id != sdmConector.Id);
            if (IsIdentificadorExist == true)
            {
                ModelState.AddModelError("Identificador", "Identificador já existe");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    TempData["Confirmacao"] = sdmConector.Identificador + " foi alterado com sucesso!";


                    _context.Update(sdmConector);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SdmConectorExists(sdmConector.Id))
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
            return View(sdmConector);
        }

        // GET: SdmConectors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sdmConector = await _context.SdmConectors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sdmConector == null)
            {
                return NotFound();
            }

            return View(sdmConector);
        }

        // POST: SdmConectors/Delete/5
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var sdmConector = await _context.SdmConectors.FindAsync(id);
            TempData["Confirmacao"] = sdmConector.Identificador + " foi excluído com sucesso!";
            _context.SdmConectors.Remove(sdmConector);
            await _context.SaveChangesAsync();
            return Json(sdmConector.Identificador + " excluído com sucesso.");
        }

        private bool SdmConectorExists(int id)
        {
            return _context.SdmConectors.Any(e => e.Id == id);
        }
    }
}
