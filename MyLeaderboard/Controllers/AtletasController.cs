﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyLeaderboard.Data;
using MyLeaderboard.Models;
using MyLeaderboard.Models.Enums;

namespace MyLeaderboard.Controllers
{
    public class AtletasController : Controller
    {
        private readonly MyLeaderboardContext _context;

        public AtletasController(MyLeaderboardContext context)
        {
            _context = context;
        }

        // GET: Atletas
        public async Task<IActionResult> Index()
        {
              return _context.Atleta != null ? 
                          View(await _context.Atleta.ToListAsync()) :
                          Problem("Entity set 'MyLeaderboardContext.Atleta'  is null.");
        }

        // GET: Atletas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Atleta == null)
            {
                return NotFound();
            }

            var atleta = await _context.Atleta
                .FirstOrDefaultAsync(m => m.Id == id);
            if (atleta == null)
            {
                return NotFound();
            }

            return View(atleta);
        }

        // GET: Atletas/Create
        public IActionResult Create()
        {
            ViewBag.categories = Enum.GetValues(typeof(Category))
                .Cast<Category>()
                .Select(a => new SelectListItem
                {
                    Value = a.ToString(),
                    Text = a.ToString()
                }).ToList();

            return View();
        }

        // POST: Atletas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Atleta atleta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(atleta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(atleta);
        }

        // GET: Atletas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Atleta == null)
            {
                return NotFound();
            }

            var atleta = await _context.Atleta.FindAsync(id);
            if (atleta == null)
            {
                return NotFound();
            }
            return View(atleta);
        }

        // POST: Atletas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Category,Score1,Score2,Score3")] Atleta atleta)
        {
            if (id != atleta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(atleta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AtletaExists(atleta.Id))
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
            return View(atleta);
        }

        // GET: Atletas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Atleta == null)
            {
                return NotFound();
            }

            var atleta = await _context.Atleta
                .FirstOrDefaultAsync(m => m.Id == id);
            if (atleta == null)
            {
                return NotFound();
            }

            return View(atleta);
        }

        // POST: Atletas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Atleta == null)
            {
                return Problem("Entity set 'MyLeaderboardContext.Atleta'  is null.");
            }
            var atleta = await _context.Atleta.FindAsync(id);
            if (atleta != null)
            {
                _context.Atleta.Remove(atleta);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AtletaExists(int id)
        {
          return (_context.Atleta?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
