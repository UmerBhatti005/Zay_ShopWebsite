using IdentityProjectPractise.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLibrary.Models
{
    public class ProductModel
    {
        public ProductModel()
        {
            ProductImages = new List<ProductImageModel>();
        }
        //[Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public bool isFeatured { get; set; }
        public DateTime PostedDate { get; set; }
        public int Quantity { get; set; }
        public int NoofSales { get; set; }
        public StatusModel statuses { get; set; }
        public GenderModel genders { get; set; }
        public CategoryModel categories { get; set; }
        public virtual ColorsModel colors { get; set; }
        public virtual ProductSizeModel productSizes { get; set; }
        public virtual ICollection<ProductImageModel> ProductImages { get; set; }
        [ForeignKey("applicationUser")]
        public string Username { get; set; }
        public SignUpUserModel applicationUser { get; set; }

    }
}
