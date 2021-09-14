using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Core.Models
{
    public class ShoppingCart
    {
        [MinLength(1), MaxLength(15),Required(AllowEmptyStrings = false)]
        public string Name { get; set; }
        public int Id { get; set; }
        public DateTime? ForDate { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
