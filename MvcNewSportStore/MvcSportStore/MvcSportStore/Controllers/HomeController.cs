using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MvcSportStore.Data;
using MvcSportStore.Models;
using MvcSportStore.ViewModels;

namespace MvcSportStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        StoreDbContext _context;
        ProductRepository _repo;
        public HomeController(ILogger<HomeController> logger, StoreDbContext context)
        {
            _logger = logger;
            _context = context;   
            _repo = new ProductRepository(_context.Products);

            // _context -> Dependency Injection
            // _repo -> normal class with Products as constructor parameter
        }
        public IActionResult Index(int id = 1, string? category=null)
        {
            var productModel = _repo.GetProductModel(id, category);
            return View(productModel);

            //int filter = PagingSettings.ProductPagination;
            //return View(_context.Products.Take(filter));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
