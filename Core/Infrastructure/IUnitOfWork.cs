using System;
using Core.Models.Repositories;

namespace Core.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {

        IEmployeeRepo Employees{ get; }
        ITaskRepo Tasks { get; }

        IProjectRepo Projects { get; }

        int Complete();
    }
}