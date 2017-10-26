using System;
namespace CustomersystemBLL.BusinessObjects
{
    public class CustomerBO
    {
        public int Id;
        public string firstName;
        public string lastName;
        public string Address;

        public string FullName
        {
            get { return $"{firstName} {lastName}"; }

        }
    }
}
