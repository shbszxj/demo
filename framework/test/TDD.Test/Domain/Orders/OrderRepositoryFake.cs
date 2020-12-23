using System.Collections.Generic;
using System.Linq;

namespace TDD.Test.Domain.Orders
{
    public class OrderRepositoryFake : IOrderRepository
    {
        private readonly ICollection<Order> _theOrders = new List<Order>();

        public Order GetOrder(int orderNumber)
        {
            return _theOrders.SingleOrDefault(o => o.OrderNumber == orderNumber);
        }

        public void AddOrder(Order order)
        {
            int theNumberOfOrdersBefore = _theOrders.Count;

            _theOrders.Add(order);
        }

        public IList<Order> GetOrders(Customer customer)
        {
            return _theOrders.Where(o => o.Customer == customer).ToList();
        }
    }
}
