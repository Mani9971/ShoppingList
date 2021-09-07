using System;
using System.Collections.Generic;

#nullable disable

namespace ShoppingList.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int AvailableCount { get; set; }

        public string Description { get; set; }

    }
}
