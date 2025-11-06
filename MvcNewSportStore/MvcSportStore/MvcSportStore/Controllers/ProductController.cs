using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcSportStore.Data;
using MvcSportStore.Models;

namespace MvcSportStore.Controllers
{
    public class ProductController : Controller
    {
        StoreDbContext _context;
        public ProductController(StoreDbContext context)
        {
            _context = context;
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View();
                       
        }
    }
}
