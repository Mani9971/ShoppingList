using ShoppingList.Core.Models;
using ShoppingList.Core.Repositories;
using ShoppingList.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IUnitOfWork _db;
        public ShoppingCartService(IUnitOfWork db)
        {
            _db = db;
        }
        public async Task<bool> Add(ShoppingCart entity)
        {
            if(entity.ForDate.HasValue && entity.ForDate.Value>= DateTime.Now.Date)
            {
                using (_db)
                {
                   var a = await _db.ShoppingCart.Add(entity);
                    if (a > 0) return true;
                }
            }
            return false;
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ShoppingCart> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ShoppingCart>> GetAll()
        {
            using (_db)
            {
                return await _db.ShoppingCart.GetAll();
            };
        }

        public async Task<ShoppingCart> GetShoppingCartWithProducts(int id)
        {
            using (_db)
            {
                return await _db.ShoppingCart.GetShoppingCartWithProducts(id);
            }
        }

        public Task<bool> Update(ShoppingCart entity)
        {
            throw new NotImplementedException();
        }
    }
}
