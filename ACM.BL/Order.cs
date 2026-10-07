using System;

namespace ACM.BL
{
    public class Order
    {
        public Order() { }

        public Order(int orderId)
        {
            OrderId = orderId;
        }

        public int OrderId { get; internal set; }
        
        // Связь представлена идентификатором, а не объектом
        public int CustomerId { get; set; } 
        
        public DateTimeOffset? OrderDate { get; set; }
        public Address ShippingAddress { get; set; }

        public bool Validate()
        {
            var isValid = true;
            if (OrderDate == null) isValid = false;
            if (CustomerId <= 0) isValid = false;
            return isValid;
        }
    }
}