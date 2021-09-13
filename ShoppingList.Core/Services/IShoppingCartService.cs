using ShoppingList.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Core.Services
{
    public interface IShoppingCartService
    {
        Task<ShoppingCart> Get(int id);
        Task<IEnumerable<ShoppingCart>> GetAll();
        Task<bool> Add(ShoppingCart entity);
        Task<bool> Delete(int id);
        Task<bool> Update(ShoppingCart entity);
        Task<ShoppingCart> GetShoppingCartWithProducts(int id);
    }
}
