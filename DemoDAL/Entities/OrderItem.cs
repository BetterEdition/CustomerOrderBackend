using System;
namespace CustomerSystemDAL.Entities
{
    public class OrderItem : IEntity
    {
        public string type { get; set; }
        public int Id { get; set; }

        public int Quantity { get; set; }

        public Double UnitPrice { get; set; }
    }
}
