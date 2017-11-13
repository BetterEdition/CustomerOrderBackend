using System;
using System.Collections.Generic;


namespace CustomerSystemDAL.Entities
{
    public class Customer : IEntity
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public String Address { get; set; }

        public String Age { get; set; }

        public List<Order> Orders { get; set; }

    }
}
