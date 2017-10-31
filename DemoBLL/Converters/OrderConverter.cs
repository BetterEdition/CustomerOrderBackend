using System;
using CustomerSystemBLL.BusinessObjects;
using CustomerSystemDAL.Entities;

namespace CustomerSystemBLL.Converters
{
    public class OrderConverter : IConverter<OrderBO, Order>
    {
        public OrderConverter()
        {

        }
        public OrderBO Convert(Order order)
        {
            if (order == null) { return null; }
            return new OrderBO()
            {
                Id = order.Id,
                orderDate = order.orderDate,
                deliveryDate = order.deliveryDate,
            };

        }

        public Order Convert(OrderBO order)
        {
            if (order == null) { return null; }
            return new Order()
            {
                Id = order.Id,
                orderDate = order.orderDate,
                deliveryDate = order.deliveryDate,
            };

        }
    }
}