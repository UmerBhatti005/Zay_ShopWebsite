using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLibrary
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey("Parent")]
        public int? ParentId { get; set; }

        public virtual Category Parent { get; set; }
    }
}
