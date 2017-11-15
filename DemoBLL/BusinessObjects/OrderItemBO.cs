using System;
namespace CustomerSystemBLL.BusinessObjects
{
    public class OrderItemBO
    {
        public int Id { get; set; }

        public string ItemName { get; set; }
        public int Quantity { get; set; }

        public Double UnitPrice { get; set; }
    }
}
