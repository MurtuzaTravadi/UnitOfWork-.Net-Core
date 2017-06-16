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
    public class UserHotelBooksController : Controller
    {
        private readonly AirlineContext _context;

        public UserHotelBooksController(AirlineContext context)
        {
            _context = context;    
        }

        // GET: UserHotelBooks
        public async Task<IActionResult> Index()
        {
            return View(await _context.UserHotelBooks.ToListAsync());
        }

        // GET: UserHotelBooks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userHotelBook = await _context.UserHotelBooks
                .SingleOrDefaultAsync(m => m.Id == id);
            if (userHotelBook == null)
            {
                return NotFound();
            }

            return View(userHotelBook);
        }

        // GET: UserHotelBooks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserHotelBooks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,UserId,InTime,OutTime,Price,DateCreated,CreatedBy,DateModified,ModifiedBy")] UserHotelBook userHotelBook)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userHotelBook);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(userHotelBook);
        }

        // GET: UserHotelBooks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userHotelBook = await _context.UserHotelBooks.SingleOrDefaultAsync(m => m.Id == id);
            if (userHotelBook == null)
            {
                return NotFound();
            }
            return View(userHotelBook);
        }

        // POST: UserHotelBooks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,UserId,InTime,OutTime,Price,DateCreated,CreatedBy,DateModified,ModifiedBy")] UserHotelBook userHotelBook)
        {
            if (id != userHotelBook.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userHotelBook);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserHotelBookExists(userHotelBook.Id))
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
            return View(userHotelBook);
        }

        // GET: UserHotelBooks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userHotelBook = await _context.UserHotelBooks
                .SingleOrDefaultAsync(m => m.Id == id);
            if (userHotelBook == null)
            {
                return NotFound();
            }

            return View(userHotelBook);
        }

        // POST: UserHotelBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userHotelBook = await _context.UserHotelBooks.SingleOrDefaultAsync(m => m.Id == id);
            _context.UserHotelBooks.Remove(userHotelBook);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool UserHotelBookExists(int id)
        {
            return _context.UserHotelBooks.Any(e => e.Id == id);
        }
    }
}
