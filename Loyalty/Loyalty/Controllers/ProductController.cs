using System.Collections.Generic;
using System.Linq;
using Loyalty.DB;
using Loyalty.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Loyalty.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDBContext _db;
        public ProductController(ApplicationDBContext db)
        {
            this._db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Product> productsList = _db.Products.Include(item => item.Category);
            return View(productsList);
        }
        public IActionResult Create()
        {
            SelectList objCategory = new SelectList(_db.Categorys, "Id", "Name");
            ViewData["CategoryOptions"] = objCategory;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product obj)
        {

            if (ModelState.IsValid)
            {
                _db.Products.Add(obj);
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
            Product obj = _db.Products.Include(item => item.Category).FirstOrDefault(item => item.Id == Id);
            if (obj == null)
            {
                return NotFound();
            }
            SelectList objCategory = new SelectList(_db.Categorys, "Id", "Name", obj.Category.Id);
            ViewData["CategoryOptions"] = objCategory;
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Product obj)
        {
            if (ModelState.IsValid)
            {
                _db.Products.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            Product obj = _db.Products.Include(item => item.Category).FirstOrDefault(item => item.Id == Id);
            if(obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteProduct(int? Id)
        {
            if(Id == null)
            {
                return NotFound();
            }
            Product obj = _db.Products.Find(Id);
            if(obj == null)
            {
                return NotFound();
            }
            _db.Products.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}