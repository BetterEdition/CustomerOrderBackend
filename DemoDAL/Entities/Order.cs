using System;

namespace CustomerSystemDAL.Entities
{
    public class Order : IEntity
    {
        public int Id { get; set; }
        public DateTime orderDate { get; set; }
        public DateTime deliveryDate { get; set; }
    }
}