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
            if (entity.ForDate.HasValue && entity.ForDate.Value >= DateTime.Now.Date)
            {
                using (_db)
                {
                    var a = await _db.ShoppingCart.Add(entity);
                    if (a > 0) return true;
                }
            }
            return false;
        }

        public async Task<ShoppingCart> AddProductToShoppingCart(Product product, int id)
        {
            using (_db)
            {
                var shoppingCart = await _db.ShoppingCart.AddProductToShoppingCart(product, id);
                return shoppingCart;
            };
        }

        public async Task<bool> Delete(int id)
        {
            using (_db)
            {
                var a = await _db.ShoppingCart.Delete(id);
                if (a > 0) return true;
            };
            return false;
        }

        public async Task<ShoppingCart> Get(int id)
        {
            using (_db)
            {
                return await _db.ShoppingCart.Get(id);
            };
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

        public async Task<bool> Update(ShoppingCart entity)
        {
            if (entity.ForDate.HasValue && entity.ForDate.Value >= DateTime.Now.Date)
            {
                using (_db)
                {
                    var a = await _db.ShoppingCart.Update(entity);
                    if (a > 0) return true;
                };
            }
            return false;
        }
    }
}
