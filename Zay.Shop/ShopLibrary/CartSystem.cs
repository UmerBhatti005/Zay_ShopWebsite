using IdentityProjectPractise.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLibrary
{
    public class CartSystem
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public float Price { get; set; }

        public byte[] Image { get; set; }

        public int Quantity { get; set; }
        public virtual Report report { get; set; }

        public virtual ProductSize productSize { get; set; }

        public virtual Colors colors { get; set; }
        [ForeignKey("applicationUser")]
        public string Username { get; set; }
        public virtual ApplicationUser applicationUser { get; set; }
    }
}
