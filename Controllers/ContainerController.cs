/*Desenvolvido por:
  
  Pedro Xavier Oliveira CB3027376
  Leandro Felix Nunes CB3026159

 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BLContainerManager.Data;
using BLContainerManager.Models;

namespace BLContainerManager.Controllers
{
    public class ContainerController : Controller
    {
        private readonly AppDbContext _context;

        public ContainerController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Container
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Containers.Include(c => c.BL);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Container/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var container = await _context.Containers
                .Include(c => c.BL)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (container == null)
            {
                return NotFound();
            }

            return View(container);
        }

        // GET: Container/Create
        public IActionResult Create()
        {
            ViewData["BLID"] = new SelectList(_context.BLs, "ID", "Numero");
            var tipos = new List<string> { "", "Dry", "Refeer" };
            ViewData["Tipos"] = new SelectList(tipos);
            var tamanhos = new List<string> { "", "20", "40" };
            ViewData["Tamanhos"] = new SelectList(tamanhos);
            return View();
        }

        // POST: Container/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Numero,Tipo,Tamanho,BLID")] Container container)
        {

            Console.WriteLine($"ModelState.IsValid: {ModelState.IsValid}");

            foreach (var state in ModelState)
            {
                foreach (var error in state.Value.Errors)
                {
                    Console.WriteLine($"Campo: {state.Key} → Erro: {error.ErrorMessage}");
                }
            }

            if (ModelState.IsValid)
            {
                _context.Add(container);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BLID"] = new SelectList(_context.BLs, "ID", "Numero", container.BLID);
            return View(container);
        }

        // GET: Container/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var container = await _context.Containers.FindAsync(id);
            if (container == null)
            {
                return NotFound();
            }
            ViewData["BLID"] = new SelectList(_context.BLs, "ID", "Numero", container.BLID);
            return View(container);
        }

        // POST: Container/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Numero,Tipo,Tamanho,BLID")] Container container)
        {
            if (id != container.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(container);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContainerExists(container.ID))
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
            ViewData["BLID"] = new SelectList(_context.BLs, "ID", "Numero", container.BLID);
            return View(container);
        }

        // GET: Container/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var container = await _context.Containers
                .Include(c => c.BL)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (container == null)
            {
                return NotFound();
            }

            return View(container);
        }

        // POST: Container/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var container = await _context.Containers.FindAsync(id);
            if (container != null)
            {
                _context.Containers.Remove(container);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContainerExists(int id)
        {
            return _context.Containers.Any(e => e.ID == id);
        }
    }
}
