using System.Collections.Generic;

namespace TDD.Test.Domain.Orders
{
    internal interface IOrderRepository
    {
        IList<Order> GetOrders(Customer customer);

        Order GetOrder(int orderNumber);

        void AddOrder(Order order);
    }
}
