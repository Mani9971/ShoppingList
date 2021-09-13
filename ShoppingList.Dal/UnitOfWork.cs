using ShoppingList.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Dal
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ShoppingListDatabaseContext _db;
        private ShoppingCartRepository shoppingCartRepository;
        private ProductRepository productRepository;
        public UnitOfWork(ShoppingListDatabaseContext db)
        {
            _db = db;
        }
        public IProductRepository Products => productRepository ?? new ProductRepository(_db);

        public IShoppingCartRepository ShoppingCart => shoppingCartRepository ?? new ShoppingCartRepository(_db);

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
