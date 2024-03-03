using final_portfolio.Data;
using final_portfolio.Models;
using Microsoft.AspNetCore.Mvc;

namespace final_portfolio.Controllers
{
    public class AboutController : Controller
    {
        private ApplicationDbContext  _db; 

        public AboutController(ApplicationDbContext db)
        {
            _db = db; 
        }
        public IActionResult Index()
        {
            About data = _db.Abouts.FirstOrDefault();
            return View(data);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            About categoryFromDb = _db.Abouts.Find(id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        [HttpPost]
        public IActionResult Edit(About obj)
        {
            if (ModelState.IsValid)
            {
                _db.Abouts.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
