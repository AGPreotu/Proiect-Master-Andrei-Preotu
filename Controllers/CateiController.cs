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
    public class CateiController : Controller
    {
        private readonly DogShowContext _context;

        public CateiController(DogShowContext context)
        {
            _context = context;
        }

        // GET: Catei
        public async Task<IActionResult> Index(string sortOrder,string currentFilter,string searchString,int? pageNumber, int? id)
        {

                ViewData["CurrentSort"] = "sortOrder";
                ViewData["NumeSortParm"] = String.IsNullOrEmpty(sortOrder) ? "nume_desc": "";
                ViewData["RasaSortParm"] = String.IsNullOrEmpty(sortOrder) ? "rasa_desc" :"";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var catei = from c in _context.Catei select c;
            if (!String.IsNullOrEmpty(searchString))
            {
                catei = catei.Where(s => s.Rasa.Contains(searchString));
            }

            switch (sortOrder)
                {
                    case "nume_desc":
                        catei = catei.OrderByDescending(c => c.Nume);
                        break;
                    case "rasa_desc":
                        catei = catei.OrderByDescending(c => c.Rasa);
                        break;
                    default:
                    catei = catei.OrderBy(c => c.Nume);
                        break;
                }
            int pageSize = 3;
            return View(await PaginatedList<Catel>.CreateAsync(catei.AsNoTracking(), pageNumber ?? 1, pageSize));
            }

        // GET: Catei/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var catel = await _context.Catei
            .Include(c => c.Premii)
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.ID == id);
            if (catel == null)
            {
                return NotFound();
            }

            return View(catel);
        }

        // GET: Catei/Create
        public IActionResult Create()
        {
            ViewData["StapanID"] = new SelectList(_context.Stapani, "ID", "ID");
            return View();
        }

        // POST: Catei/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nume,Rasa,StapanID")] Catel catel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(catel);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                ModelState.AddModelError("", "Unable to save changes. " +   "Try again, and if the problem persists ");
            }
            ViewData["StapanID"] = new SelectList(_context.Stapani, "ID", "ID", catel.StapanID);
            return View(catel);
        }

        // GET: Catei/Edit/5
        public async Task<IActionResult> EditPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catelToUpdate = await _context.Catei.FirstOrDefaultAsync(c => c.ID == id);

            if (await TryUpdateModelAsync<Catel>(
                catelToUpdate
                ,
                "",
                c => c.Nume, 
                c => c.Rasa, 
                c => c.StapanID))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException /* ex */)
                {
                    ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists");
                }
            }
            return View(catelToUpdate);
        }

        // POST: Catei/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Nume,Rasa,StapanID")] Catel catel)
        {
            if (id != catel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(catel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatelExists(catel.ID))
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
            ViewData["StapanID"] = new SelectList(_context.Stapani, "ID", "ID", catel.StapanID);
            return View(catel);
        }

        // GET: Catei/Delete/5
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catel = await _context.Catei
                .AsNoTracking()
                .Include(c => c.Stapan)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (catel == null)
            {
                return NotFound();
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] =
                "Delete failed. Try again";
            }
            return View(catel);
        }

        // POST: Catei/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var catel = await _context.Catei.FindAsync(id);
            if (catel == null)
            {
                return RedirectToAction(nameof(Index));
            }
            try
            {
                _context.Catei.Remove(catel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException /* ex */)
            {

                return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
            }
        }

        private bool CatelExists(int id)
        {
            return _context.Catei.Any(e => e.ID == id);
        }
    }
}
