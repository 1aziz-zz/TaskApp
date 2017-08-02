using System;
using System.Collections.Generic;
using System.Linq;
using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Core.Infrastructure
{
    public abstract class Repository<T> : IRepository<T>, IDisposable where T : Entity
    {
        protected readonly DbContext Context;
        private bool _disposed;

        protected Repository(DbContext dbContext)
        {
            Context = dbContext;
        }


        public T GetById(int? id)
        {
            return Context.Set<T>().Find(id);
        }

        public void Remove(T obj)
        {
            Context.Set<T>().Remove(obj);
        }

        public void Add(T obj)
        {
            Context.Set<T>().Add(obj);
        }

        public void Update(T t)
        {
            Context.Entry(t).State = EntityState.Modified;
        }

        public List<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }
            _disposed = true;
        }

  
    }
}