namespace TDD.Test.Domain.Orders
{
    public class Product
    {
        private readonly string _description;

        public decimal UnitPrice { get; }

        public Product(string description, decimal unitPrice)
        {
            _description = description;
            UnitPrice = unitPrice;
        }
    }
}
