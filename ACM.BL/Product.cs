using System;

namespace ACM.BL
{
    public class Product
    {
        public Product() { }

        public Product(int productId)
        {
            ProductId = productId;
        }

        public int ProductId { get; internal set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal? CurrentPrice { get; set; }

        public bool Validate()
        {
            var isValid = true;
            if (string.IsNullOrWhiteSpace(ProductName)) isValid = false;
            if (CurrentPrice == null || CurrentPrice <= 0) isValid = false;
            return isValid;
        }
    }
}