using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Simple_Shop_Management_System.Data;
using Simple_Shop_Management_System.Models;

namespace Simple_Shop_Management_System.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _db;

        public ProductController(AppDbContext db)
        {
            _db = db;
        }

        // GET: Products List
        public IActionResult Index()
        {
            var products = _db.Products.Include(p => p.Category).ToList();
            return View(products);
        }

        public IActionResult About()
        {
            return View();
        }

        // GET: Create New Product
        public IActionResult NewItem()
        {
            PopulateCategories();
            return View();
        }

        // POST: Create New Product
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NewItem(Product product)
        {
            if (ModelState.IsValid)
            {
                _db.Products.Add(product);
                _db.SaveChanges();
                TempData["SuccessDate"] = "Item has been added successfully!";
                return RedirectToAction(nameof(Index));
            }

            PopulateCategories(product.CategoryId);
            return View(product);
        }

        // GET: Edit Product
        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();

            var product = _db.Products.Find(id);
            if (product == null) return NotFound();

            PopulateCategories(product.CategoryId);
            return View(product);
        }

        // POST: Edit Product
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Product product)
        {
            if (product.Price < 0)
                ModelState.AddModelError(nameof(product.Price), "Price must be greater than zero.");

            if (ModelState.IsValid)
            {
                _db.Products.Update(product);
                _db.SaveChanges();
                TempData["SuccessDate"] = "Item has been edited successfully!";
                return RedirectToAction(nameof(Index));
            }

            PopulateCategories(product.CategoryId);
            return View(product);
        }

        // GET: Delete Product
        public IActionResult DeleteItem(int? id)
        {
            if (id == null) return NotFound();

            var product = _db.Products.Include(p => p.Category).FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();

            return View(product);
        }

        // POST: Delete Product
        [HttpPost, ActionName("DeleteItem")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteItemConfirmed(int id)
        {
            var product = _db.Products.Find(id);
            if (product == null) return NotFound();

            _db.Products.Remove(product);
            _db.SaveChanges();
            TempData["SuccessDate"] = "Item has been deleted successfully!";
            return RedirectToAction(nameof(Index));
        }

        private void PopulateCategories(int selectedId = 0)
        {
            ViewBag.Categorylist = new SelectList(_db.Categories.ToList(), "Id", "Name", selectedId);
        }
    }
}
