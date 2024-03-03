using final_portfolio.Data;
using final_portfolio.Models;
using Microsoft.AspNetCore.Mvc;

namespace final_portfolio.Controllers
{
    public class ContactController : Controller
    {
        private ApplicationDbContext _db;
        public ContactController(ApplicationDbContext db)
        {
            _db = db; 
        }
        public IActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Index(Contact obj)
        {
            _db.Contacts.Add(obj);
            _db.SaveChanges();
            return View();
        }
    }
}
