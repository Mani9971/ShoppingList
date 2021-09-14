using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ShoppingList.Core.Models
{
    public class Product
    {
        public int Id { get; set; }

        [MinLength(1), MaxLength(15), Required(AllowEmptyStrings = false)]
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsChecked { get; set; }
        [RegularExpression("^[1-9][\\.\\d]*(,\\d+)?$", ErrorMessage = "Price must be a number.")]
        public decimal Price { get; set; }
        public ICollection<ShoppingCart> ShoppingCarts { get; set; }
    }
}
