using ShoppingList.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Core.Repositories
{
    public interface IShoppingCartRepository : IRepository <ShoppingCart>
    {
        public Task<ShoppingCart> GetShoppingCartWithProducts(int id);
        Task<ShoppingCart> AddProductToShoppingCart(Product product, int id);
    }
}
