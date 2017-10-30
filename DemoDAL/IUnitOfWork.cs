using System;
using CustomerSystemDAL.Repositories;
using CustomerSystemDAL.UOW;

namespace CustomerSystemDAL
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository CustomerRepository { get; }

        int Complete();
    }
}