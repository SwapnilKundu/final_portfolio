using final_portfolio.Data;
using final_portfolio.Models;
using Microsoft.AspNetCore.Mvc;

namespace final_portfolio.Controllers
{
    public class MessageController : Controller
    {
        private ApplicationDbContext _db;
        public MessageController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Contact> list = _db.Contacts.ToList();
            return View(list);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Contact categoryFromDb = _db.Contacts.Find(id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }


        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int id)
        {
            Contact obj = _db.Contacts.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Contacts.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
            if (ModelState.IsValid)
            {
                _db.Contacts.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
