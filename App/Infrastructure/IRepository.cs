using System.Collections.Generic;
using Core.Models;

namespace Core.Infrastructure
{
    public interface IRepository<T> where T : Entity
    {
        T GetById(int? id);

        void Remove(T obj);

        void Add(T obj);

        void Update(T t);

        List<T> GetAll();

        void Dispose();
    }
}