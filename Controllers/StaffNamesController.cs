using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VisitorManagmentSystem.Data;
using VisitorManagmentSystem.Models;

namespace VisitorManagmentSystem.Controllers
{
    [Authorize]
    public class StaffNamesController : Controller
    {
        
        private readonly VisitorDbContext _context;

        public StaffNamesController(VisitorDbContext context)
        {
            _context = context;
        }

        // GET: StaffNames
        public async Task<IActionResult> Index()
        {
            return View(await _context.Staffnames.ToListAsync());
        }

        // GET: StaffNames/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staffNames = await _context.Staffnames
                .FirstOrDefaultAsync(m => m.Id == id);
            if (staffNames == null)
            {
                return NotFound();
            }

            return View(staffNames);
        }

        // GET: StaffNames/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StaffNames/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Department,VisitorCount")] StaffNames staffNames)
        {
            if (ModelState.IsValid)
            {
                _context.Add(staffNames);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(staffNames);
        }

        // GET: StaffNames/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staffNames = await _context.Staffnames.FindAsync(id);
            if (staffNames == null)
            {
                return NotFound();
            }
            return View(staffNames);
        }

        // POST: StaffNames/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Department,VisitorCount")] StaffNames staffNames)
        {
            if (id != staffNames.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(staffNames);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StaffNamesExists(staffNames.Id))
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
            return View(staffNames);
        }

        // GET: StaffNames/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staffNames = await _context.Staffnames
                .FirstOrDefaultAsync(m => m.Id == id);
            if (staffNames == null)
            {
                return NotFound();
            }

            return View(staffNames);
        }

        // POST: StaffNames/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var staffNames = await _context.Staffnames.FindAsync(id);
            _context.Staffnames.Remove(staffNames);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StaffNamesExists(int id)
        {
            return _context.Staffnames.Any(e => e.Id == id);
        }
    }
}
