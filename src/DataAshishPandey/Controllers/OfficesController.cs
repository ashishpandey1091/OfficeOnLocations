using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using DataAshishPandey.Models;

namespace DataAshishPandey.Controllers
{
    public class OfficesController : Controller
    {
        private AppDbContext _context;

        public OfficesController(AppDbContext context)
        {
            _context = context;    
        }

        // GET: Offices
        public IActionResult Index()
        {
            return View(_context.offices.ToList());
        }

        // GET: Offices/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Office office = _context.offices.Single(m => m.officeID == id);
            if (office == null)
            {
                return HttpNotFound();
            }

            return View(office);
        }

        // GET: Offices/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Offices/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Office office)
        {
            if (ModelState.IsValid)
            {
                _context.offices.Add(office);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(office);
        }

        // GET: Offices/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Office office = _context.offices.Single(m => m.officeID == id);
            if (office == null)
            {
                return HttpNotFound();
            }
            return View(office);
        }

        // POST: Offices/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Office office)
        {
            if (ModelState.IsValid)
            {
                _context.Update(office);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(office);
        }

        // GET: Offices/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Office office = _context.offices.Single(m => m.officeID == id);
            if (office == null)
            {
                return HttpNotFound();
            }

            return View(office);
        }

        // POST: Offices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Office office = _context.offices.Single(m => m.officeID == id);
            _context.offices.Remove(office);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
