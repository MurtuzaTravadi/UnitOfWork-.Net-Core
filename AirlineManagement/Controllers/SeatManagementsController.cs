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
    public class SeatManagementsController : Controller
    {
        private readonly AirlineContext _context;

        public SeatManagementsController(AirlineContext context)
        {
            _context = context;    
        }

        // GET: SeatManagements
        public async Task<IActionResult> Index()
        {
            return View(await _context.SeatManagements.ToListAsync());
        }

        // GET: SeatManagements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seatManagement = await _context.SeatManagements
                .SingleOrDefaultAsync(m => m.Id == id);
            if (seatManagement == null)
            {
                return NotFound();
            }

            return View(seatManagement);
        }

        // GET: SeatManagements/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SeatManagements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TotalSeat,RouteId,AvalibaleSeat,BookSeat,Price,DateCreated,CreatedBy,DateModify,ModifiedBy")] SeatManagement seatManagement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(seatManagement);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(seatManagement);
        }

        // GET: SeatManagements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seatManagement = await _context.SeatManagements.SingleOrDefaultAsync(m => m.Id == id);
            if (seatManagement == null)
            {
                return NotFound();
            }
            return View(seatManagement);
        }

        // POST: SeatManagements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TotalSeat,RouteId,AvalibaleSeat,BookSeat,Price,DateCreated,CreatedBy,DateModify,ModifiedBy")] SeatManagement seatManagement)
        {
            if (id != seatManagement.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(seatManagement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SeatManagementExists(seatManagement.Id))
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
            return View(seatManagement);
        }

        // GET: SeatManagements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seatManagement = await _context.SeatManagements
                .SingleOrDefaultAsync(m => m.Id == id);
            if (seatManagement == null)
            {
                return NotFound();
            }

            return View(seatManagement);
        }

        // POST: SeatManagements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var seatManagement = await _context.SeatManagements.SingleOrDefaultAsync(m => m.Id == id);
            _context.SeatManagements.Remove(seatManagement);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool SeatManagementExists(int id)
        {
            return _context.SeatManagements.Any(e => e.Id == id);
        }
    }
}
