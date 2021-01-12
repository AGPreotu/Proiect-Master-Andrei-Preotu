using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proiect_Master_Andrei_Preotu.Data;
using Proiect_Master_Andrei_Preotu.Models;
using Proiect_Master_Andrei_Preotu.Models.DogShowViewmodels;

namespace Proiect_Master_Andrei_Preotu.Controllers
{
    public class StapaniController : Controller
    {
        private readonly DogShowContext _context;

        public StapaniController(DogShowContext context)
        {
            _context = context;
        }

        // GET: Stapani
        public async Task<IActionResult> Index(int? id)
        {
            var viewModel = new StapanIndexData();
            viewModel.Stapani = await _context.Stapani
            .Include(i => i.Catei)
            .AsNoTracking()
            .ToListAsync();

            if (id != null)
            {
                ViewData["CatelID"] = id.Value;
                Stapan stapan = viewModel.Stapani.Where(
                i => i.ID == id.Value).Single();
                viewModel.Catei = stapan.Catei;
            }

            return View(viewModel);
        }

        // GET: Stapani/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stapan = await _context.Stapani
                .FirstOrDefaultAsync(m => m.ID == id);
            if (stapan == null)
            {
                return NotFound();
            }

            return View(stapan);
        }

        // GET: Stapani/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Stapani/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nume,Prenume,Varsta,NrTelefon")] Stapan stapan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stapan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(stapan);
        }

        // GET: Stapani/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stapan = await _context.Stapani.FindAsync(id);
            if (stapan == null)
            {
                return NotFound();
            }
            return View(stapan);
        }

        // POST: Stapani/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Nume,Prenume,Varsta,NrTelefon")] Stapan stapan)
        {
            if (id != stapan.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stapan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StapanExists(stapan.ID))
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
            return View(stapan);
        }

        // GET: Stapani/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stapan = await _context.Stapani
                .FirstOrDefaultAsync(m => m.ID == id);
            if (stapan == null)
            {
                return NotFound();
            }

            return View(stapan);
        }

        // POST: Stapani/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stapan = await _context.Stapani.FindAsync(id);
            _context.Stapani.Remove(stapan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StapanExists(int id)
        {
            return _context.Stapani.Any(e => e.ID == id);
        }
    }
}
