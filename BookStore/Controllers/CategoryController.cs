using Bookstore.Data;
using Bookstore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Bookstore.Controllers
{
    public class CategoryController : Controller
    {
        // To add remove update data from controller we were normally creating object of our dbcontext
        // But we are not using it here because we already register it as out service so we can directly use them in constructor as follows
        private readonly ApplicationDbContext _db;// Local variable
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }
        //Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "Display Order cannot exactly match with the Name");
            }
            //if (obj.Name == "test")
            //{
            //    ModelState.AddModelError("", "'test' is an invalid value");
            //}
            if (ModelState.IsValid) 
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["Success"] = "Category created successfully";
                return RedirectToAction("Index", "Category");
            }
            return View();
        }
        //Update
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryFromDb = _db.Categories.Find(id);
            //Category? categoryFromDb1 = _db.Categories.FirstOrDefault(u => u.Id == id);
            //Category? categoryFromDb2 = _db.Categories.Where(u => u.Id == id).FirstOrDefault();
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["Success"] = "Category updated successfully";
                return RedirectToAction("Index", "Category");
            }
            return View();
        }
        //Delete

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryFromDb = _db.Categories.Find(id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Category? obj = _db.Categories.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            TempData["Success"] = "Category removed successfully"; 
            return RedirectToAction("Index", "Category");
        }

    }
}
