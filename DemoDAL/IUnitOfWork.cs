using System;
using CustomerSystemDAL.Repositories;
using CustomerSystemDAL.UOW;

namespace CustomerSystemDAL
{
    public interface IUnitOfWork : IDisposable
    {
        CustomerRepository CustomerRepository { get; }

        int Complete();
    }
}