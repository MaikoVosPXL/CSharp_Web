using Microsoft.AspNetCore.Mvc;
using MvcSportStore.Data;

namespace MvcSportStore.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private StoreDbContext _context;
        public NavigationMenuViewComponent(StoreDbContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            return View(
                _context.Products
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x));
        }
    }
}
