using System;
using System.Collections.Generic;
using System.Linq;
using ACM.BL;

namespace ACM.DAL
{
    public class InMemoryProductRepository : IProductRepository
    {
        private static int _nextId = 1;
        private static readonly List<Product> _store = new List<Product>();

        public int Save(Product product)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));

            if (product.ProductId == 0)
            {
                product.ProductId = _nextId++;
                _store.Add(product);
            }
            else
            {
                var existing = _store.FirstOrDefault(p => p.ProductId == product.ProductId);
                if (existing != null)
                {
                    _store.Remove(existing);
                    _store.Add(product);
                }
            }
            return product.ProductId;
        }

        public Product GetById(int productId) => _store.FirstOrDefault(p => p.ProductId == productId);
        public List<Product> GetAll() => new List<Product>(_store);
    }
}