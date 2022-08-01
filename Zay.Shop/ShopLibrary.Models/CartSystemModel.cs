using IdentityProjectPractise.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLibrary.Models
{
    public class CartSystemModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public float Price { get; set; }

        public string Image { get; set; }

        public int Quantity { get; set; }

        public virtual ReportModel report { get; set; }

        public ProductSizeModel productSize { get; set; }

        public ColorsModel colors { get; set; }
        [ForeignKey("applicationUser")]
        public string Username { get; set; }
        public SignUpUserModel applicationUser { get; set; }
    }
}
