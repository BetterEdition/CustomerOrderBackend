using System;
using System.Collections.Generic;
namespace CustomerSystemBLL.BusinessObjects
{
    public class CustomerBO : IBusinessObject
    {
        public int Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Address { get; set; }
        public String Age { get; set; }


        public List<int> orderIds { get; set; }
        public List<OrderBO> orders { get; set; }


        public string FullName
        {
            get { return $"{FirstName} {LastName}"; }
        }



    }

}
