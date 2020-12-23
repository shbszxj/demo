namespace TDD.Test.Domain.Orders
{
    public class OrderFactory
    {
        public static Order CreateOrder(Customer customer)
        {
            return new Order(customer);
        }
    }
}
