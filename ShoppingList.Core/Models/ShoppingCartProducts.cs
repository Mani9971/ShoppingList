using ShoppingList.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingList.Core.Models
{
    public class ShoppingCartProducts
    {
        public ShoppingCart ShoppingCart { get; set; }
        public Product Product { get; set; }
    }
}
