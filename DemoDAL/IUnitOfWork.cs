using System;
using CustomerSystemDAL.UOW;

namespace CustomerSystemDAL
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository CustomerRepository { get; }
       
        int Complete();
    }
}
