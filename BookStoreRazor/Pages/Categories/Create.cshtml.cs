using BookStoreRazor.Data;
using BookStoreRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookStoreRazor.Pages.Categories
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]
        public Category Category { get; set; }
        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
        }
        //public IActionResult OnPost(Category Obj)
        public IActionResult OnPost()
        {
            //_db.Categories.Add(Obj);
            _db.Categories.Add(Category);
            _db.SaveChanges();
            TempData["Success"] = "Category created successfully";
            return RedirectToPage("Index");

        }
    }
}
