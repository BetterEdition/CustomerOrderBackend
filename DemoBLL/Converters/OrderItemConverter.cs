using System;
using CustomerSystemBLL.BusinessObjects;
using CustomerSystemDAL.Entities;
namespace CustomerSystemBLL.Converters
{
    public class OrderItemConverter : IConverter<OrderItemBO, OrderItem>
    {
        public OrderItemConverter()
        {
        }

        public OrderItemBO Convert(OrderItem oItem)
        {
            if (oItem == null) { return null; }
            return new OrderItemBO()
            {
                Id = oItem.Id,
                Quantity = oItem.Quantity,
                UnitPrice = oItem.UnitPrice,

            };
        }

        public OrderItem Convert(OrderItemBO oItem)
        {
            if (oItem == null) { return null; }
            return new OrderItem()
            {
                Id = oItem.Id,
                Quantity = oItem.Quantity,
                UnitPrice = oItem.UnitPrice,
            };
        }
    }
}
