using System;
using System.Collections.Generic;
using System.Linq;
using ACM.BL;

namespace ACM.DAL
{
    public class InMemoryOrderItemRepository : IOrderItemRepository
    {
        private static int _nextId = 1;
        private static readonly List<OrderItem> _store = new List<OrderItem>();

        public int Save(OrderItem orderItem)
        {
            if (orderItem == null) throw new ArgumentNullException(nameof(orderItem));

            if (orderItem.OrderItemId == 0)
            {
                orderItem.OrderItemId = _nextId++;
                _store.Add(orderItem);
            }
            else
            {
                var existing = _store.FirstOrDefault(oi => oi.OrderItemId == orderItem.OrderItemId);
                if (existing != null)
                {
                    _store.Remove(existing);
                    _store.Add(orderItem);
                }
            }
            return orderItem.OrderItemId;
        }

        public OrderItem GetById(int orderItemId) => _store.FirstOrDefault(oi => oi.OrderItemId == orderItemId);
        public List<OrderItem> GetAll() => new List<OrderItem>(_store);
    }
}