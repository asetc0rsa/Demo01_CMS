using System;
using System.Collections.Generic;
using System.Linq;
using ACM.BL;

namespace ACM.DAL
{
    public class InMemoryOrderRepository : IOrderRepository
    {
        private static int _nextOrderId = 1;
        private static int _nextOrderItemId = 1;
        private static readonly List<Order> _orders = new List<Order>();
        private static readonly List<OrderItem> _orderItems = new List<OrderItem>();

        public int Save(Order order)
        {
            if (order == null) throw new ArgumentNullException(nameof(order));

            if (order.OrderId == 0)
            {
                order.OrderId = _nextOrderId++;
                _orders.Add(order);
            }
            else
            {
                var existing = _orders.FirstOrDefault(o => o.OrderId == order.OrderId);
                if (existing != null)
                {
                    _orders.Remove(existing);
                    _orders.Add(order);
                }
            }

            // Сохраняем позиции заказа
            if (order.OrderItems != null)
            {
                foreach (var item in order.OrderItems)
                {
                    item.OrderId = order.OrderId; // Убеждаемся, что связь установлена
                    
                    if (item.OrderItemId == 0)
                    {
                        item.OrderItemId = _nextOrderItemId++;
                        _orderItems.Add(item);
                    }
                    else
                    {
                        var existingItem = _orderItems.FirstOrDefault(i => i.OrderItemId == item.OrderItemId);
                        if (existingItem != null)
                        {
                            _orderItems.Remove(existingItem);
                            _orderItems.Add(item);
                        }
                    }
                }
            }

            return order.OrderId;
        }

        public Order GetById(int orderId)
        {
            var order = _orders.FirstOrDefault(o => o.OrderId == orderId);
            if (order != null)
            {
                order.OrderItems = _orderItems.Where(i => i.OrderId == orderId).ToList();
            }
            return order;
        }

        public List<Order> GetAll()
        {
            var orders = new List<Order>(_orders);
            foreach (var order in orders)
            {
                order.OrderItems = _orderItems.Where(i => i.OrderId == order.OrderId).ToList();
            }
            return orders;
        }
    }
}