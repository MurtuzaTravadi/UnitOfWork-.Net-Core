using AirlineManagementSystem.Abstract;
using Microsoft.AspNetCore.Mvc;
using AirlineManagement.Repository;
using System;
using Microsoft.EntityFrameworkCore;
using AirlineManagement.Models.Domain.Model;

namespace AirlineManagement.Controllers
{
    public class StudentsController : Controller
    {
        private IUnitOfWork _unitofWork;


        public StudentsController(IUnitOfWork unitOfWork)
        {
            _unitofWork = unitOfWork;
        }

        // GET: Students
        public ActionResult Index()
        {
            var abc = _unitofWork.AirlineRepository.GetAll();
            return View(abc);
        }

        // GET: Students/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var airline = _unitofWork.AirlineRepository.Get(id);
            if (airline == null)
            {
                return NotFound();
            }

            return View(airline);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name")] Airline airline)
        {
            if (ModelState.IsValid)
            {
                airline.DateCreated = DateTime.Now;
                airline.DateModified = DateTime.Now;
                airline.CreatedBy = 2;
                airline.ModifiedBy = 1;
                _unitofWork.AirlineRepository.Add(airline);
                return RedirectToAction("Index");
            }
            return View(airline);
        }

        // GET: Students/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var airline = _unitofWork.AirlineRepository.Get(id);
            if (airline == null)
            {
                return NotFound();
            }
            return View(airline);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id, Name")] Airline airline)
        {
            if (id != airline.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _unitofWork.AirlineRepository.Update(airline);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AirlineExists(airline.Id))
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
            return View(airline);
        }

        // GET: Students/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var airline = _unitofWork.AirlineRepository.AirlineExists(id);
            return View(airline);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {

            bool result = _unitofWork.AirlineRepository.Delete(id);
            if (result == true)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Delete");
            }
        }

        private bool AirlineExists(int id)
        {
            return _unitofWork.AirlineRepository.AirlineExistsBool(id);
        }
    }
}
