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
        private IEnumerable<Product> GetProducts(int productPage)
        {
            return _products
                .OrderBy(p => p.ProductId)
                .Skip((productPage - 1) * PagingSettings.ProductPagination)
                .Take(PagingSettings.ProductPagination);
        }
        private PagingInfo GetPagingInfo(int productPage)
        {
            var pagingInfo = new PagingInfo();
            pagingInfo.CurrentPage = productPage;
            pagingInfo.PageItems = PagingSettings.ProductPagination;
            pagingInfo.TotalItems = _products.Count();
            return pagingInfo;
        }
        public ProductModel GetProductModel(int productPage)
        {
            var productModel = new ProductModel();
            productModel.Products = GetProducts(productPage);
            productModel.PagingInfo = GetPagingInfo(productPage);
            return productModel;
        }
    }
    // OPGELET dit is geen dependency injection - geen controller class
}
