using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Models
{
    public class ShoppingCartProducts
    {
        public Product Product { get; set; }
        public ShoppingCart ShoppingList { get; set; }
        public int ProductId { get; set; }
        public int ShoppingListId { get; set; }

    }
}
