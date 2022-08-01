using Microsoft.EntityFrameworkCore;
using ShopLibrary.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLibrary
{
    public class ShopCatalogRepository : IShopCatalogRepository
    {
        #region CartSytem

        public List<CartSystem> GetCartSystemC(int reportId)
        {
            using (ShopContext context = new ShopContext())
            {
                if (reportId == 1 || reportId == 2)
                {
                    var cart = (from p in context.cartSystem
                            .Include(x => x.productSize)
                            .Include(x => x.colors)
                            .Include(x => x.applicationUser)
                            .Include(x => x.report)
                                where p.report.Id == reportId
                                select p).ToList();
                    return cart;
                }
                else
                {
                    return null;
                }
                //var temp = (from p in context.cartSystem
                //            .Include(x => x.productSize)
                //            .Include(x => x.colors)
                //            .Include(x => x.applicationUser)
                //            .Include(x => x.report)
                //            select p).ToList();
                //return temp;
            }
        }

        #endregion
        #region Product
        //getbyID
        public Product GetProduct(int id)
        {
            using (ShopContext context = new ShopContext())
            {
                var temp = (from p in context.Products
                            .Include(i => i.categories)
                            .Include(i => i.statuses)
                            .Include(i => i.genders)
                            .Include(i => i.colors)
                            .Include(i => i.productSizes)
                            where p.Id == id
                            select p).FirstOrDefault();
                return temp;
            }
        }

        public List<Product> GetSpecificAdvFromUser(string Username)
        {
            using (ShopContext context = new ShopContext())
            {
                var temp = (from p in context.Products
                           .Include(x => x.categories)
                           .ThenInclude(x => x.Parent)
                           .Include(x => x.ProductImages)
                           .Include(x => x.productSizes)
                           .Include(x => x.colors)
                           .Include(x => x.statuses)
                           .Include(x => x.genders)
                           .Include(x => x.applicationUser)
                            where p.applicationUser.UserName == Username
                            select p).ToList();
                return temp;
            }
        }
        //getbyName
        //getall
        public List<Product> GetProducts()
        {
            using (ShopContext context = new ShopContext())
            {
                List<Product> Pros = (from p in context.Products
                             .Include(i => i.categories)
                             .Include(i => i.statuses)
                             .Include(i => i.genders)
                             .Include(i => i.colors)
                            .Include(i => i.productSizes)
                            .Include(i => i.ProductImages)
                                      select p).ToList();
                return Pros;
            }
        }
        //GetActiveproduct
        public List<Product> GetActiveProducts(int statusId)
        {
            using (ShopContext context = new ShopContext())
            {
                if (statusId == 2)
                {
                    List<Product> Pros = (from p in context.Products
                             .Include(i => i.categories)
                             .ThenInclude(i => i.Parent)
                             .Include(i => i.statuses)
                             .Include(i => i.genders)
                             .Include(i => i.ProductImages)
                             .Include(i => i.colors)
                             .Include(i => i.productSizes)
                             .AsNoTracking()
                                          where p.statuses.Id == statusId
                                          select p).ToList();
                    return Pros;
                }
                else
                {
                    List<Product> Pros = (from p in context.Products
                             .Include(i => i.categories)
                             .Include(i => i.statuses)
                             .Include(i => i.genders)
                                          select p).ToList();
                    return Pros;
                }

            }
        }
        //getall:sorted:newestfirst
        public List<Product> GetNewestProducts()
        {
            using (ShopContext context = new ShopContext())
            {
                var Prods = (from p in context.Products
                            .Include(i => i.categories)
                            .Include(i => i.statuses)
                            .Include(i => i.genders)
                             orderby p.PostedDate
                             select p).ToList();
                return Prods;
            }
        }
        //getallbyCategory
        public List<Product> GetProductsByCategoryId(int categoryid)
        {
            using (ShopContext context = new ShopContext())
            {
                var Prods = (from p in context.Products
                             .Include(i => i.categories)
                             .Include(i => i.statuses)
                             .Include(i => i.genders)
                             where p.categories.Id == categoryid
                             select p).ToList();
                return Prods;
            }
        }
        //getallFeatured
        public List<Product> GetFeaturedProducts()
        {
            using (ShopContext context = new ShopContext())
            {
                var prods = (from p in context.Products
                             .Include(i => i.categories)
                             .ThenInclude(i => i.Parent)
                            .Include(i => i.statuses)
                            .Include(i => i.genders)
                            .Include(i => i.colors)
                            .Include(i => i.ProductImages)
                            .Include(i => i.productSizes)
                            .Include(i => i.applicationUser)
                             where p.isFeatured == true
                             select p).Take(3).ToList();
                return prods;
            }
        }
        //getallbestSeller
        public List<Product> GetBestSellers()
        {
            using (ShopContext context = new ShopContext())
            {
                var prods = (from p in context.Products
                             .Include(i => i.categories)
                             .Include(i => i.statuses)
                             .Include(i => i.genders)
                             orderby p.NoofSales descending
                             select p).ToList();
                return prods;
            }
        }
        //getallbyGender
        public List<Product> GetProductsForGender(int id)
        {
            using (ShopContext context = new ShopContext())
            {
                var prods = (from p in context.Products
                            .Include(i => i.categories)
                            .Include(i => i.statuses)
                            .Include(i => i.genders)
                             where p.genders.Id == id
                             select p).ToList();
                return prods;
            }
        }
        //getall:sorted:newestfirst
        public List<Product> GetNewestProductsForGender(int id)
        {
            using (ShopContext context = new ShopContext())
            {
                var prods = (from p in context.Products
                            .Include(i => i.categories)
                            .Include(i => i.statuses)
                            .Include(i => i.genders)
                             where p.genders.Id == id
                             orderby p.PostedDate
                             select p).ToList();
                return prods;
            }
        }
        //getallbyColor
        //public List<Product> GetProductsByColor(string color)
        //{
        //    using (ShopContext context = new ShopContext())
        //    {
        //        var prods = (from p in context.Products
        //                    .Include(i => i.categories)
        //                    .Include(i => i.statuses)
        //                    .Include(i => i.genders)
        //                     where p.
        //                     select p).ToList();

        //        return prods;
        //    }
        //}
        //getall:sorted:newestfirst
        //public List<Product> GetNewestProductsByColor(string color)
        //{
        //    using (ShopContext context = new ShopContext())
        //    {
        //        var prods = (from p in context.Products
        //                    .Include(i => i.categories)
        //                    .Include(i => i.statuses)
        //                    .Include(i => i.genders)
        //                     where p.Color == color.ToLower()
        //                     orderby p.PostedDate
        //                     select p).ToList();

        //        return prods;
        //    }
        //}

        //add Product

        public Product AddProduct(Product product)
        {
            using (ShopContext context = new ShopContext())
            {
                context.Entry(product.categories).State = EntityState.Unchanged;
                context.Entry(product.statuses).State = EntityState.Unchanged;
                context.Entry(product.genders).State = EntityState.Unchanged;
                context.Entry(product.productSizes).State = EntityState.Unchanged;
                context.Entry(product.colors).State = EntityState.Unchanged;
                context.Entry(product?.applicationUser).State = EntityState.Unchanged;
                context.Add<Product>(product);
                context.SaveChanges();
                return product;
            }
        }

        //update product
        public Product UpdateProduct(int id, Product product)
        {
            using (ShopContext context = new ShopContext())
            {
                Product found = context.Find<Product>(id);
                context.Entry(product.statuses).State = EntityState.Unchanged;
                context.Entry(product.genders).State = EntityState.Unchanged;
                context.Entry(product.categories).State = EntityState.Unchanged;

                if (found != null)
                {
                    found.Name = product.Name;
                    found.Description = product.Description;
                    found.Price = product.Price;
                    found.colors = product.colors;
                    found.isFeatured = product.isFeatured;
                    found.PostedDate = product.PostedDate;
                    found.Quantity = product.Quantity;
                    found.NoofSales = product.NoofSales;
                    found.statuses = product.statuses;
                    found.genders = product.genders;
                    found.categories = product.categories;
                    context.SaveChanges();
                }
                return found;
            }
        }

        //delete Product
        public Product DeleteProduct(int id)
        {
            using (ShopContext context = new ShopContext())
            {
                Product found = context.Find<Product>(id);
                if (found != null)
                {
                    context.Remove(found);
                    context.SaveChanges();
                }
                return found;
            }
        }

        #endregion

        #region Category
        //getbyId
        public Category GetCategoryById(int id)
        {
            using (ShopContext context = new ShopContext())
            {
                var cat = (from c in context.Categories
                           .Include(p => p.Parent)
                           where c.Id == id
                           select c).First();
                return cat;
            }
        }
        //getall
        public List<Category> GetCategories()
        {
            using (ShopContext context = new ShopContext())
            {
                var cat = (from c in context.Categories
                           .Include(p => p.Parent)
                           select c).ToList();

                return cat;
            }
        }
        //getallTopCat
        public List<Category> GetTopCategories()
        {
            using (ShopContext context = new ShopContext())
            {
                var cat = (from c in context.Categories
                           .Include(p => p.Parent)
                           where c.Parent == null
                           select c).ToList();

                return cat;
            }
        }
        //getallsubcategoriesbyCategory
        public List<Category> GetSubCategoriesByCategory(Category category)
        {
            using (ShopContext context = new ShopContext())
            {
                var cat = (from c in context.Categories
                           .Include(p => p.Parent)
                           where c.Parent.Id == category.Id
                           select c).ToList();

                return cat;
            }
        }
        public List<Category> GetSubCategoriesByCategoryId(int id)
        {
            using (ShopContext context = new ShopContext())
            {
                var cat = (from c in context.Categories
                           .Include(p => p.Parent)
                           where c.Parent.Id == id
                           select c).ToList();

                return cat;
            }
        }
        //add
        public Category AddCategory(Category category)
        {
            using (ShopContext context = new ShopContext())
            {
                if (category != null)
                {
                    if (category.Parent != null)
                    {
                        context.Entry(category.Parent).State = EntityState.Unchanged;
                    }
                    context.Add<Category>(category);
                    context.SaveChanges();
                }
                return category;
            }
        }
        public Category UpdateCategory(int id, Category category)
        {
            using (ShopContext context = new ShopContext())
            {
                Category found = context.Find<Category>(id);
                if (found != null)
                {
                    if (!string.IsNullOrWhiteSpace(category.Name))
                    {
                        found.Name = category.Name;
                    }
                    context.Entry(category.Parent).State = EntityState.Unchanged;
                    found.Parent = category.Parent;
                    context.SaveChanges();
                }
                return found;
            }
        }
        public Category DeleteCategory(int id)
        {
            using (ShopContext context = new ShopContext())
            {
                Category found = context.Find<Category>(id);
                if (found != null)
                {
                    context.Remove(found);
                    context.SaveChanges();
                }
                return found;
            }
        }
        #endregion

        //#region ProductSize
        ////getall
        //public List<ProductSize> GetProductSizes()
        //{
        //    using (ShopContext context = new ShopContext())
        //    {
        //        var sizes = (from s in context.ProductSizes
        //                     select s).ToList();
        //        return sizes;
        //    }
        //}
        ////getbyid
        //public ProductSize GetProductSize(int id)
        //{
        //    using (ShopContext context = new ShopContext())
        //    {
        //        var size = (from s in context.ProductSizes
        //                    where s.Id == id
        //                    select s).First();
        //        return size;
        //    }
        //}

        //#endregion

        //#region Gender
        ////getall
        //public List<Gender> GetGenders()
        //{
        //    using (ShopContext context = new ShopContext())
        //    {
        //        var gen = (from g in context.Genders
        //                   select g).ToList();
        //        return gen;
        //    }
        //}
        ////getbyid
        //public Gender GetGenderbyID(int id)
        //{
        //    using (ShopContext context = new ShopContext())
        //    {
        //        var gen = (from g in context.Genders
        //                   where g.Id == id
        //                   select g).First();
        //        return gen;
        //    }
        //}

        //#endregion

        //#region Status
        ////getall
        //public List<Status> GetStatuses()
        //{
        //    using (ShopContext context = new ShopContext())
        //    {
        //        var stat = (from s in context.Statuses
        //                    select s).ToList();
        //        return stat;
        //    }
        //}
        ////getbyid
        //public Status GetStatusbyId(int id)
        //{
        //    using (ShopContext context = new ShopContext())
        //    {
        //        var stat = (from s in context.Statuses
        //                    where s.Id == id
        //                    select s).First();
        //        return stat;
        //    }
        //}

        //#endregion
    }
}
