using System;
using System.Collections.Generic;

#nullable disable

namespace ShoppingList.Core.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsChecked { get; set; }
        public decimal Price { get; set; }
        public IList<ShoppingCartProducts> ShoppingListProducts { get; set; }
    }
}
