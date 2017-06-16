using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AirlineManagement.Models.Domain.Model;
using AirlineManagement.Models.Infrastructure.Data;

namespace AirlineManagement.Controllers
{
    public class AirportsController : Controller
    {
        private readonly AirlineContext _context;

        public AirportsController(AirlineContext context)
        {
            _context = context;    
        }

        // GET: Airports
        public async Task<IActionResult> Index()
        {
            return View(await _context.Airports.ToListAsync());
        }

        // GET: Airports/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var airport = await _context.Airports
                .SingleOrDefaultAsync(m => m.Id == id);
            if (airport == null)
            {
                return NotFound();
            }

            return View(airport);
        }

        // GET: Airports/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Airports/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,DateCreated,CreatedBy,DateModified,ModifiedBy")] Airport airport)
        {
            if (ModelState.IsValid)
            {
                _context.Add(airport);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(airport);
        }

        // GET: Airports/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var airport = await _context.Airports.SingleOrDefaultAsync(m => m.Id == id);
            if (airport == null)
            {
                return NotFound();
            }
            return View(airport);
        }

        // POST: Airports/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,DateCreated,CreatedBy,DateModified,ModifiedBy")] Airport airport)
        {
            if (id != airport.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(airport);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AirportExists(airport.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(airport);
        }

        // GET: Airports/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var airport = await _context.Airports
                .SingleOrDefaultAsync(m => m.Id == id);
            if (airport == null)
            {
                return NotFound();
            }

            return View(airport);
        }

        // POST: Airports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var airport = await _context.Airports.SingleOrDefaultAsync(m => m.Id == id);
            _context.Airports.Remove(airport);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool AirportExists(int id)
        {
            return _context.Airports.Any(e => e.Id == id);
        }
    }
}
