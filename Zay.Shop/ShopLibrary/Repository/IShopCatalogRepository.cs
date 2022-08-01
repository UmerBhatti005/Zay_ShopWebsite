using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLibrary.Helper
{
    public interface IShopCatalogRepository
    {
        List<CartSystem> GetCartSystemC(int reportId);
        Product GetProduct(int id);

        List<Product> GetProducts();
        List<Product> GetActiveProducts(int statusId);

        List<Product> GetNewestProducts();

        List<Product> GetProductsByCategoryId(int categoryid);

        List<Product> GetFeaturedProducts();

        List<Product> GetBestSellers();

        List<Product> GetProductsForGender(int id);
        List<Product> GetSpecificAdvFromUser(string Username);

        List<Product> GetNewestProductsForGender(int id);

        //List<Product> GetProductsByColor(string color);

        //List<Product> GetNewestProductsByColor(string color);

        Product AddProduct(Product product);

        Product UpdateProduct(int id, Product product);

        Product DeleteProduct(int id);

    }
}
