using MvcSportStore.Models;

namespace MvcSportStore.ViewModels
{
    public class ProductRepository
    {
        List<Product> _products;
        public ProductRepository(IEnumerable<Product> products)
        {
            _products = products.ToList();
        }
        private IEnumerable<Product> GetProducts(int productPage, string? category)
        {
            return _products
                .Where(p => category is null || p.Category == category)
                .OrderBy(p => p.ProductId)
                .Skip((productPage - 1) * PagingSettings.ProductPagination)
                .Take(PagingSettings.ProductPagination);
        }
        private PagingInfo GetPagingInfo(int productPage, string? category)
        {
            var pagingInfo = new PagingInfo();
            var totalItems = (category is null)
                ? _products.Count()
                : _products.Where(p => p.Category == category).Count();
            pagingInfo.CurrentPage = productPage;
            pagingInfo.Category = category;
            pagingInfo.PageItems = PagingSettings.ProductPagination;
            pagingInfo.TotalItems = totalItems;
            return pagingInfo;
        }
        public ProductModel GetProductModel(int productPage, string? category)
        {
            var productModel = new ProductModel();
            productModel.Products = GetProducts(productPage, category);
            productModel.PagingInfo = GetPagingInfo(productPage, category);
            return productModel;
        }
    }
    // OPGELET dit is geen dependency injection - geen controller class
}
