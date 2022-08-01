using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLibrary.Models
{
    public class RateModel
    {
        public int Id { get; set; }

        public int rating { get; set; }
        public int productId { get; set; }
        public ProductModel products { get; set; }
    }
}
