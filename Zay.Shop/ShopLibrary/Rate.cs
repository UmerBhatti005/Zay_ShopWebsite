using IdentityProjectPractise.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLibrary
{
    public class Rate
    {
        public int Id { get; set; }

        public int rating { get; set; }
        [ForeignKey("products")]
        public int productId { get; set; }
        public virtual Product products { get; set; }

    }
}
