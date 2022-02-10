using System.Linq;
using Loyalty.DB;
using Loyalty.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Loyalty.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDBContext _db;
        public CategoryController(ApplicationDBContext db)
        {
            this._db = db;
        }
        public IActionResult Index()
        {
            return View(_db.Categorys);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {

            if (ModelState.IsValid)
            {
                _db.Categorys.Add(obj);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(obj);
        }
        public IActionResult Update(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            Category obj = _db.Categorys.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Category obj)
        {

            if (ModelState.IsValid)
            {
                _db.Categorys.Update(obj);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(obj);
        }
        public IActionResult Delete(int? Id){

            if (Id == null) 
            {
                return NotFound();
            }
            Category obj = _db.Categorys.Include(x => x.Products).FirstOrDefault(x => x.Id == Id);           
            if (obj == null) {
                return NotFound();
            }

            return View(obj);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteCategory(int? id)
        {
            if (id == null) 
            {
                return NotFound();
            }
            Category obj = _db.Categorys.Find(id);
            if (obj == null) 
            {
                return NotFound();
            }
            _db.Categorys.Remove(obj);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}