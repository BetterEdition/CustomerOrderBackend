using System;

namespace CustomerSystemDAL
{
    public interface IUnitOfWork : IDisposable
    {
        //ICustomerRepository CustomerRepository { get; }
       
        int Complete();
    }
}
