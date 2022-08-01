using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLibrary
{
    public class ProductImage
    {
        public int Id { get; set; }

        public int Rank { get; set; }

        public string Caption { get; set; }
        [Required]
        public byte[] Pics { get; set; }


    }
}
