using System;
using System.Collections.Generic;
using System.Linq;
using ACM.BL;

namespace ACM.DAL
{
    public class InMemoryOrderRepository : IOrderRepository
    {
        private static int _nextId = 1;
        private static readonly List<Order> _store = new List<Order>();

        public int Save(Order order)
        {
            if (order == null) throw new ArgumentNullException(nameof(order));

            if (order.OrderId == 0)
            {
                order.OrderId = _nextId++;
                _store.Add(order);
            }
            else
            {
                var existing = _store.FirstOrDefault(o => o.OrderId == order.OrderId);
                if (existing != null)
                {
                    _store.Remove(existing);
                    _store.Add(order);
                }
            }
            return order.OrderId;
        }

        public Order GetById(int orderId) => _store.FirstOrDefault(o => o.OrderId == orderId);
        public List<Order> GetAll() => new List<Order>(_store);
    }
}