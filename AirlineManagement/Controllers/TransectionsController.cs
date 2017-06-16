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
    public class TransectionsController : Controller
    {
        private readonly AirlineContext _context;

        public TransectionsController(AirlineContext context)
        {
            _context = context;    
        }

        // GET: Transections
        public async Task<IActionResult> Index()
        {
            return View(await _context.Transections.ToListAsync());
        }

        // GET: Transections/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transection = await _context.Transections
                .SingleOrDefaultAsync(m => m.Id == id);
            if (transection == null)
            {
                return NotFound();
            }

            return View(transection);
        }

        // GET: Transections/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Transections/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AirlineId,AirportId,UserId,Payment,DateCreated,CreatedBy,DateModified,ModifiedBy")] Transection transection)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transection);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(transection);
        }

        // GET: Transections/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transection = await _context.Transections.SingleOrDefaultAsync(m => m.Id == id);
            if (transection == null)
            {
                return NotFound();
            }
            return View(transection);
        }

        // POST: Transections/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AirlineId,AirportId,UserId,Payment,DateCreated,CreatedBy,DateModified,ModifiedBy")] Transection transection)
        {
            if (id != transection.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transection);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransectionExists(transection.Id))
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
            return View(transection);
        }

        // GET: Transections/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transection = await _context.Transections
                .SingleOrDefaultAsync(m => m.Id == id);
            if (transection == null)
            {
                return NotFound();
            }

            return View(transection);
        }

        // POST: Transections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transection = await _context.Transections.SingleOrDefaultAsync(m => m.Id == id);
            _context.Transections.Remove(transection);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool TransectionExists(int id)
        {
            return _context.Transections.Any(e => e.Id == id);
        }
    }
}
