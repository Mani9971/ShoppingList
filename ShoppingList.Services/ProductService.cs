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
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _db;

        public ProductService(IUnitOfWork db)
        {
            _db = db;
        }

        public async Task<bool> Add(Product entity)
        {
            using (_db)
            {
                var a = await _db.Products.Add(entity);
                if (a > 0) return true;
            }
            return false;
        }

        public async Task<bool> Delete(int id)
        {
            using (_db)
            {
                var a = await _db.Products.Delete(id);
                if (a > 0) return true;
            };
            return false;
        }

        public async Task<Product> Get(int id)
        {
            using (_db)
            {
                return await _db.Products.Get(id);
            };
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            using (_db)
            {
                return await _db.Products.GetAll();
            };
        }

        public async Task<bool> Update(Product entity)
        {

            using (_db)
            {
                var a = await _db.Products.Update(entity);
                if (a > 0) return true;
            };
            return false;
        }
    }
}
