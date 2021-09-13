﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Core.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public DateTime? ForDate { get; set; }
        public IList<ShoppingCartProducts> ShoppingListProducts { get; set; }
    }
}
