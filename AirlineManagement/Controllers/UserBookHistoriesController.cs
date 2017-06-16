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
    public class UserBookHistoriesController : Controller
    {
        private readonly AirlineContext _context;

        public UserBookHistoriesController(AirlineContext context)
        {
            _context = context;    
        }

        // GET: UserBookHistories
        public async Task<IActionResult> Index()
        {
            return View(await _context.UserBookHistorys.ToListAsync());
        }

        // GET: UserBookHistories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userBookHistory = await _context.UserBookHistorys
                .SingleOrDefaultAsync(m => m.Id == id);
            if (userBookHistory == null)
            {
                return NotFound();
            }

            return View(userBookHistory);
        }

        // GET: UserBookHistories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserBookHistories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,TransectionId,DateCreated,CreatedBy,DateModify,ModifiedBy")] UserBookHistory userBookHistory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userBookHistory);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(userBookHistory);
        }

        // GET: UserBookHistories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userBookHistory = await _context.UserBookHistorys.SingleOrDefaultAsync(m => m.Id == id);
            if (userBookHistory == null)
            {
                return NotFound();
            }
            return View(userBookHistory);
        }

        // POST: UserBookHistories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,TransectionId,DateCreated,CreatedBy,DateModify,ModifiedBy")] UserBookHistory userBookHistory)
        {
            if (id != userBookHistory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userBookHistory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserBookHistoryExists(userBookHistory.Id))
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
            return View(userBookHistory);
        }

        // GET: UserBookHistories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userBookHistory = await _context.UserBookHistorys
                .SingleOrDefaultAsync(m => m.Id == id);
            if (userBookHistory == null)
            {
                return NotFound();
            }

            return View(userBookHistory);
        }

        // POST: UserBookHistories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userBookHistory = await _context.UserBookHistorys.SingleOrDefaultAsync(m => m.Id == id);
            _context.UserBookHistorys.Remove(userBookHistory);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool UserBookHistoryExists(int id)
        {
            return _context.UserBookHistorys.Any(e => e.Id == id);
        }
    }
}
