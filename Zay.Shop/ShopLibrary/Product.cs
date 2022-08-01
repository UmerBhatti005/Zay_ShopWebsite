using IdentityProjectPractise.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLibrary
{
    public class Product
    {
        public Product()
        {
            ProductImages = new List<ProductImage>();
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
        public virtual Status statuses { get; set; }
        public virtual Gender genders { get; set; }
        public virtual Category categories { get; set; }
        public virtual Colors colors { get; set; }
        public virtual ProductSize productSizes { get; set; }
        public virtual ICollection<ProductImage> ProductImages { get; set; }
        [ForeignKey("applicationUser")]
        public string Username { get; set; }
        public virtual ApplicationUser applicationUser { get; set; }

    }
}
