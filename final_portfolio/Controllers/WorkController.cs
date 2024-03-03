using final_portfolio.Data;
using final_portfolio.Models;
using Microsoft.AspNetCore.Mvc;

namespace final_portfolio.Controllers
{
    public class WorkController : Controller
    {
        private ApplicationDbContext _db;
        public WorkController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Work> list = _db.Works.ToList();
            return View(list);
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(Work obj)
        {
            if (ModelState.IsValid)
            {
                _db.Works.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Work categoryFromDb = _db.Works.Find(id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Work obj)
        {
            if (ModelState.IsValid)
            {
                _db.Works.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Work categoryFromDb = _db.Works.Find(id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }


        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int id)
        {
            Work obj = _db.Works.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Works.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");

            if (ModelState.IsValid)
            {
                _db.Works.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}
