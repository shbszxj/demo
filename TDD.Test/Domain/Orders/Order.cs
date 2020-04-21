using System;
using System.Collections.Generic;
using System.Linq;

namespace TDD.Test.Domain.Orders
{
    public class Order
    {
        public Customer Customer { get; }

        public DateTime OrderDate { get; }

        private readonly int _orderNumber;
        public int OrderNumber => _orderNumber;

        public decimal TotalAmount => _orderLines.Sum(ol => ol.TotalAmount);

        private readonly IList<OrderLine> _orderLines = new List<OrderLine>();

        public IEnumerable<OrderLine> OrderLines => _orderLines;

        public Order(Customer customer)
        {
            Customer = customer;
            OrderDate = DateTime.Now;
        }

        public void AddOrderLine(OrderLine orderLine)
        {
            _orderLines.Add(orderLine);
        }
    }
}
