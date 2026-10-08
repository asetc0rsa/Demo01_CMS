using System;
using System.Collections.Generic;

namespace ACM.BL
{
    public class Order
    {
        public Order() 
        {
            OrderItems = new List<OrderItem>();
        }

        public Order(int orderId) : this()
        {
            OrderId = orderId;
        }

        public int OrderId { get; internal set; }
        public int CustomerId { get; set; }
        public DateTimeOffset? OrderDate { get; set; }
        public Address ShippingAddress { get; set; }
        public List<OrderItem> OrderItems { get; set; }

        public bool Validate()
        {
            var isValid = true;
            if (OrderDate == null) isValid = false;
            if (CustomerId <= 0) isValid = false;
            return isValid;
        }
    }
}