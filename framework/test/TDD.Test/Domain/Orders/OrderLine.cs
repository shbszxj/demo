namespace TDD.Test.Domain.Orders
{
    public class OrderLine
    {
        public int NumberOfUnits { get; set; }

        public Product Product { get; }

        public decimal Price = 0;

        public decimal TotalAmount => Price * NumberOfUnits;

        public OrderLine(Product product)
        {
            Product = product;
            Price = product.UnitPrice;
        }
    }
}
