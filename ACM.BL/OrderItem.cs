using System;

namespace ACM.BL
{
    public class OrderItem
    {
        public OrderItem() { }

        public OrderItem(int orderItemId)
        {
            OrderItemId = orderItemId;
        }

        public int OrderItemId { get; internal set; }
        
        // Связи представлены идентификаторами
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        
        public int OrderQuantity { get; set; }
        public decimal? PurchasePrice { get; set; }

        public bool Validate()
        {
            var isValid = true;
            if (OrderId <= 0) isValid = false;
            if (ProductId <= 0) isValid = false;
            if (OrderQuantity <= 0) isValid = false;
            if (PurchasePrice == null || PurchasePrice <= 0) isValid = false;
            return isValid;
        }
    }
}