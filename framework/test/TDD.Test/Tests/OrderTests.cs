using System;
using TDD.Test.Domain.Orders;
using TDD.Test.Infrastructure;
using Xunit;

namespace TDD.Test.Tests
{
    public class OrderTests : IClassFixture<OrderRepositoryFake>
    {
        private readonly IOrderRepository _orderRepository;

        public OrderTests(OrderRepositoryFake orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [Fact]
        [Trait("OrderCreationTest", "1")]
        public void CanCreateOrder()
        {
            Order order = OrderFactory.CreateOrder(_FakeACustomer(2));

            Assert.NotNull(order);
        }

        [Fact]
        public void OrderDateIsCurrentAfterCreation()
        {
            DateTime theTimeBefore = DateTime.Now.AddMilliseconds(-1);

            Order order = OrderFactory.CreateOrder(_FakeACustomer(1));

            Assert.True(order.OrderDate > theTimeBefore);
            Assert.True(order.OrderDate < DateTime.Now.AddMilliseconds(1));
        }

        [Fact]
        public void OrderNumberIsZeroAfterCreation()
        {
            Order order = OrderFactory.CreateOrder(_FakeACustomer(3));

            Assert.Equal(0, order.OrderNumber);
        }

        [Fact]
        public void OrderNumberCantBeZeroAfterReconstitution()
        {
            int theOrderNumber = 42;

            _FakeAnOrder(theOrderNumber);

            Order order = _orderRepository.GetOrder(theOrderNumber);

            Assert.Equal(theOrderNumber, order.OrderNumber);
        }

        [Fact]
        public void CanAddOrder()
        {
            _orderRepository.AddOrder(new Order(_FakeACustomer(1)));
        }

        [Fact]
        public void CanFindOrdersViaCustomer()
        {
            Customer c = _FakeACustomer(7);

            _FakeAnOrder(42, c);
            _FakeAnOrder(12, _FakeACustomer(1));
            _FakeAnOrder(3, c);
            _FakeAnOrder(21, c);
            _FakeAnOrder(1, _FakeACustomer(2));

            Assert.Equal(3, _orderRepository.GetOrders(c).Count);
        }

        [Fact]
        public void EmptyOrderHasZeroForTotalAmount()
        {
            var order = new Order(_FakeACustomer(1));

            Assert.Equal(0, order.TotalAmount);
        }

        [Fact]
        public void OrderWithLinesHasTotalAmount()
        {
            var order = new Order(_FakeACustomer(1));

            var orderLine = new OrderLine(new Product("Chair", 52))
            {
                NumberOfUnits = 2
            };

            order.AddOrderLine(orderLine);

            Assert.Equal(104, order.TotalAmount);
        }

        private void _FakeAnOrder(int orderNumber)
        {
            Order order = new Order(_FakeACustomer(1));

            RepositoryHelper.SetFieldWhenReconstitutingFromPersistence(order, "_orderNumber", orderNumber);

            _orderRepository.AddOrder(order);
        }


        private void _FakeAnOrder(int orderNumber, Customer customer)
        {
            var order = new Order(customer);

            RepositoryHelper.SetFieldWhenReconstitutingFromPersistence(order, "_orderNumber", orderNumber);

            _orderRepository.AddOrder(order);
        }

        private Customer _FakeACustomer(int customerNumber)
        {
            var customer = new Customer();

            RepositoryHelper.SetFieldWhenReconstitutingFromPersistence(customer, "_customerNumber", customerNumber);

            return customer;
        }
    }
}
