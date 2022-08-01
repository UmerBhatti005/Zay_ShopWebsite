using AutoMapper;
using IdentityProjectPractise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLibrary.Models
{
    public static class ModelHelper
    {

        // This is extension method which takes data from view and converts into database{for able to enter in}
        #region ProductImage

        public static ProductImageModel ToModel(this ProductImage entity)
        {
            ProductImageModel model = new ProductImageModel();

            model.Id = entity.Id;
            model.Caption = entity.Caption;
            model.Rank = entity.Rank;
            if (entity.Pics != null)
            {
                model.Pics = Convert.ToBase64String(entity.Pics);
            }
            return model;
        }

        public static List<ProductImageModel> ToModelList(this IEnumerable<ProductImage> entityList)
        {
            List<ProductImageModel> modelList = new List<ProductImageModel>();

            foreach (var entity in entityList)
            {
                modelList.Add(entity.ToModel());
            }
            modelList.TrimExcess();
            return modelList;
        }

        #endregion
        #region Products
        public static ProductModel ToModel(this Product entity)
        {
            ProductModel model = new ProductModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                Price = entity.Price,
                isFeatured = entity.isFeatured,
                PostedDate = entity.PostedDate,
                Quantity = entity.Quantity,
                NoofSales = entity.NoofSales,
                statuses = entity.statuses.ToModel(),
                genders = entity.genders.ToModel(),
                categories = entity.categories.ToModel(),
                colors = entity.colors.ToModel(),
                productSizes = entity.productSizes.ToModel(),
                Username = entity.Username
            };
            if (entity.applicationUser != null)
            {
                model.applicationUser = entity.applicationUser.ToModel();
            }
            foreach (var pImg in entity.ProductImages)
            {
                if (pImg.Pics != null)
                {
                    model.ProductImages = entity.ProductImages.ToModelList();
                }
            }
            return model;

        }
        public static Product ToEntity(this ProductModel model, ApplicationUser dept)
        {
            Product entity = new Product
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                isFeatured = model.isFeatured,
                PostedDate = model.PostedDate,
                Quantity = model.Quantity,
                NoofSales = model.NoofSales,
                statuses = model.statuses.ToEntity(),
                genders = model.genders.ToEntity(),
                categories = model.categories.ToEntity(),
                colors = model.colors.ToEntity(),
                productSizes = model.productSizes.ToEntity(),
                //applicationUser = model.applicationUser.ToEntity()
                //Username = model.Username
                applicationUser = dept
            };
            if (model.ProductImages != null)
            {
                foreach (var imgModel in model.ProductImages)
                {
                    //string[] arr = new string[1];
                    //if (imgModel.Pics != null)
                    //{
                    //    arr[0] = imgModel.Pics;
                    //}

                    ProductImage imgEntity = new ProductImage
                    {
                        Id = imgModel.Id,
                        Caption = imgModel.Caption,
                        Rank = imgModel.Rank,
                        Pics = Convert.FromBase64String(imgModel.Pics)
                    };
                    entity.ProductImages.Add(imgEntity);
                }
            }
            return entity;
        }
        public static List<ProductModel> ToModelList(this List<Product> entitiesList)
        {
            List<ProductModel> modelList = new List<ProductModel>();
            foreach (var p in entitiesList)
            {
                modelList.Add(p.ToModel());
            }
            modelList.TrimExcess();
            return modelList;
        }

        #endregion
        #region applicationUser

        public static SignUpUserModel ToModel(this ApplicationUser entity)
        {
            SignUpUserModel model = new SignUpUserModel
            {
                Id = entity.Id,
                Username = entity.UserName,
                FirstName = entity.FirstName,
                LastNme = entity.LastName,
                Email = entity.Email,
                Image = Convert.ToBase64String(entity.Image),
                role = entity.role
            };
            return model;

        }
        public static ApplicationUser ToEntity(this SignUpUserModel model)
        {
            ApplicationUser entity = new ApplicationUser();
            if (model != null)
            {
                entity.Id = model.Id;
                entity.UserName = model.Username;
                entity.FirstName = model.FirstName;
                entity.LastName = model.LastNme;
                entity.Email = model.Email;
                entity.role = model.role;
            }
            if (model.Image != null)
            {
                entity.Image = Convert.FromBase64String(model.Image);
            };
            return entity;

        }
        public static List<SignUpUserModel> ToModelList(this List<ApplicationUser> entitylist)
        {
            List<SignUpUserModel> modelList = new List<SignUpUserModel>();
            foreach (var s in entitylist)
            {
                modelList.Add(s.ToModel());
            }
            modelList.TrimExcess();
            return modelList;
        }

        #endregion
        #region Categories
        public static CategoryModel ToModel(this Category entity)
        {
            CategoryModel model = new CategoryModel
            {
                Id = entity.Id,
                Name = entity.Name,
                ParentId = entity.ParentId
            };
            if (entity.Parent != null)
            {
                model.Parent = entity.Parent.ToModel();
            }
            return model;

        }
        public static Category ToEntity(this CategoryModel model)
        {
            Category entity = new Category
            {
                Id = model.Id,
                Name = model.Name
            };
            if (model.Parent != null)
            {
                entity.Parent = model.Parent.ToEntity();
            }
            return entity;
        }
        public static List<CategoryModel> ToModelList(this List<Category> entityList)
        {
            List<CategoryModel> modelList = new List<CategoryModel>();
            foreach (var s in entityList)
            {
                modelList.Add(s.ToModel());
            }
            modelList.TrimExcess();
            return modelList;
        }

        #endregion
        #region Status
        public static StatusModel ToModel(this Status entity)
        {
            StatusModel model = new StatusModel
            {
                Id = entity.Id,
                Name = entity.Name
            };
            return model;

        }
        public static List<StatusModel> ToModelList(this List<Status> entitylist)
        {
            List<StatusModel> modelList = new List<StatusModel>();
            foreach (var s in entitylist)
            {
                modelList.Add(s.ToModel());
            }
            modelList.TrimExcess();
            return modelList;
        }
        public static Status ToEntity(this StatusModel model)
        {
            Status entity = new Status
            {
                Id = model.Id,
                Name = model.Name
            };
            return entity;

        }
        #region Color

        public static ColorsModel ToModel(this Colors entity)
        {
            ColorsModel model = new ColorsModel
            {
                Id = entity.Id,
                Name = entity.Name
            };
            return model;
        }
        public static List<ColorsModel> ToModelList(this IEnumerable<Colors> entityList)
        {
            List<ColorsModel> modelList = new List<ColorsModel>();
            foreach (var s in entityList)
            {
                modelList.Add(s.ToModel());
            }
            modelList.TrimExcess();
            return modelList;
        }
        public static Colors ToEntity(this ColorsModel model)
        {
            Colors entity = new Colors
            {
                Id = model.Id,
                Name = model.Name
            };
            return entity;

        }
        public static List<Colors> ToEntityList(this IEnumerable<ColorsModel> modelList)
        {
            List<Colors> entityList = new List<Colors>();
            foreach (var m in modelList)
            {
                entityList.Add(m.ToEntity());
            }
            entityList.TrimExcess();
            return entityList;
        }

        #endregion

        #endregion
        #region ProductSize
        public static ProductSizeModel ToModel(this ProductSize entity)
        {
            ProductSizeModel model = new ProductSizeModel
            {
                Id = entity.Id,
                Name = entity.Name
            };
            return model;

        }
        public static List<ProductSizeModel> ToModelList(this IEnumerable<ProductSize> entityList)
        {
            List<ProductSizeModel> modelList = new List<ProductSizeModel>();
            foreach (var s in entityList)
            {
                modelList.Add(s.ToModel());
            }
            modelList.TrimExcess();
            return modelList;
        }
        public static ProductSize ToEntity(this ProductSizeModel model)
        {
            ProductSize entity = new ProductSize
            {
                Id = model.Id,
                Name = model.Name
            };
            return entity;

        }
        public static List<ProductSize> ToEntityList(this IEnumerable<ProductSizeModel> modelList)
        {
            List<ProductSize> entityList = new List<ProductSize>();
            foreach (var m in modelList)
            {
                entityList.Add(m.ToEntity());
            }
            entityList.TrimExcess();
            return entityList;
        }

        #endregion
        #region Gender
        public static GenderModel ToModel(this Gender entity)
        {
            GenderModel model = new GenderModel
            {
                Id = entity.Id,
                Name = entity.Name
            };
            return model;

        }
        public static Gender ToEntity(this GenderModel model)
        {
            Gender entity = new Gender
            {
                Id = model.Id,
                Name = model.Name
            };
            return entity;

        }
        public static List<GenderModel> ToModelList(this List<Gender> EntityList)
        {
            List<GenderModel> model = new List<GenderModel>();
            foreach (var g in EntityList)
            {
                model.Add(g.ToModel());
            }
            model.TrimExcess();
            return model;
        }
        #endregion
        #region CartSystem

        public static CartSystem ToEntity(this CartSystemModel model, ApplicationUser dept, Colors color, ProductSize size, Report report)
        {
            CartSystem entity = new CartSystem();

            entity.Id = model.Id;
            entity.Name = model.Name;
            entity.Price = model.Price;
            entity.Quantity = model.Quantity;
            entity.Image = Convert.FromBase64String(model.Image);
            entity.productSize = size;
            entity.colors = color;
            entity.report = report;
            entity.applicationUser = dept;
            return entity;
        }

        public static List<CartSystemModel> ToModelList(this List<CartSystem> entitiyList)
        {
            List<CartSystemModel> modelList = new List<CartSystemModel>();
            if (entitiyList != null)
            {

                foreach (var entity in entitiyList)
                {
                    modelList.Add(entity.ToModel());
                }

                modelList.TrimExcess();
            }
            return modelList;
        }

        public static CartSystemModel ToModel(this CartSystem entity)
        {
            CartSystemModel model = new CartSystemModel();
            if (entity != null)
            {
                model.Id = entity.Id;
                model.Name = entity.Name;
                model.Price = entity.Price;
                model.Quantity = entity.Quantity;
                model.Image = Convert.ToBase64String(entity.Image);
                model.productSize = entity.productSize.ToModel();
                model.colors = entity.colors.ToModel();
                model.report = entity.report.ToModel();
                model.Username = entity.Username;
                if (entity.applicationUser != null)
                {
                    model.applicationUser = entity.applicationUser.ToModel();
                }
            }
            return model;
        }

        #endregion

        #region Report

        public static ReportModel ToModel(this Report entity)
        {
            ReportModel model = new ReportModel
            {
                Id = entity.Id,
                Name = entity.Name
            };
            return model;

        }
        public static Report ToEntity(this ReportModel model)
        {
            Report entity = new Report
            {
                Id = model.Id,
                Name = model.Name
            };
            return entity;

        }
        public static List<ReportModel> ToModelList(this List<Report> EntityList)
        {
            List<ReportModel> model = new List<ReportModel>();
            foreach (var g in EntityList)
            {
                model.Add(g.ToModel());
            }
            model.TrimExcess();
            return model;
        }

        #endregion

        #region Rate

        public static RateModel ToModel(this Rate entity)
        {
            RateModel model = new RateModel
            {
                Id = entity.Id,
                rating = entity.rating,
                products = entity.products.ToModel()
            };
            return model;

        }
        public static List<RateModel> ToModelList(this List<Rate> entitylist)
        {
            List<RateModel> modelList = new List<RateModel>();
            foreach (var s in entitylist)
            {
                modelList.Add(s.ToModel());
            }
            modelList.TrimExcess();
            return modelList;
        }
        public static Rate ToEntity(this RateModel model)
        {
            Rate entity = new Rate
            {
                Id = model.Id,
                rating = model.rating,
                productId = model.productId
                //products = model.products.ToRateEntity()
            };
            return entity;

        }

        public static Product ToRateEntity(this ProductModel model)
        {
            Product entity = new Product
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                isFeatured = model.isFeatured,
                PostedDate = model.PostedDate,
                Quantity = model.Quantity,
                NoofSales = model.NoofSales,
                statuses = model.statuses.ToEntity(),
                genders = model.genders.ToEntity(),
                categories = model.categories.ToEntity(),
                colors = model.colors.ToEntity(),
                productSizes = model.productSizes.ToEntity(),
                Username = model.Username,
                applicationUser = model.applicationUser.ToEntity()
            };
            if (model.ProductImages != null)
            {
                foreach (var imgModel in model.ProductImages)
                {
                    ProductImage imgEntity = new ProductImage
                    {
                        Id = imgModel.Id,
                        Caption = imgModel.Caption,
                        Rank = imgModel.Rank,
                        Pics = Convert.FromBase64String(imgModel.Pics)
                    };
                    entity.ProductImages.Add(imgEntity);
                }
            }
            return entity;
        }
        #endregion

    }
}
