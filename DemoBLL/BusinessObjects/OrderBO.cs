using System;
namespace CustomerSystemBLL.BusinessObjects
{
    public class OrderBO : IBusinessObject
    {
        public int Id { get; set; }
        public DateTime orderDate { get; set; }
        public DateTime deliveryDate { get; set; }

        public int CustomerId { get; set; }
        public CustomerBO Customer { get; set; }
    }
}
