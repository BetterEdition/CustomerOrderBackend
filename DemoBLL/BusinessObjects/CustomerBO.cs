using System;
namespace CustomerSystemBLL.BusinessObjects
{
    public class CustomerBO : IBusinessObject
    {
        public int Id { get; set; }

        public String FirstName { get; set; }

        public String LastName { get; set; }


        public String Address { get; set; }

        public String Age { get; set; }

        public string FullName
        {
            get { return $"{FirstName} {LastName}"; }
        }
    }

}
