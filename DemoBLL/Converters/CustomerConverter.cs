using System;
using CustomerSystemBLL.BusinessObjects;
using System.Linq;
using CustomerSystemDAL.Entities;
using System.Security.Cryptography;
using System.Net.Sockets;

namespace CustomerSystemBLL.Converters
{
    public class CustomerConverter : IConverter<Customer, CustomerBO>
    {
        private OrderConverter oConv;
        public CustomerConverter()
        {
            var OConv = new OrderConverter();
        }

        public CustomerBO Convert(Customer cust)
        {

            if (cust == null) { return null; }
            return new CustomerBO()
            {
                Id = cust.Id,
                FirstName = cust.FirstName,
                LastName = cust.LastName,
                orderIds = cust.Orders?.Select(o => o.OrderId).ToList()

            };
        }

        public Customer Convert(CustomerBO cust)
        {
            if (cust == null) { return null; }
            return new Customer()
            {
                Id = cust.Id,
                Orders = cust.orderIds?.Select(oId => new CustomerOrder()
                {
                    OrderId = oId,
                    CustomerId = cust.Id
                }).ToList(),
                FirstName = cust.FirstName,
                LastName = cust.LastName,



            };
        }
    }
}