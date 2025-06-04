using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BuradayimBackend.Data;
using BuradayimBackend.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace BuradayimBackend.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected readonly AppDBContext _context;

        public RepositoryBase(AppDBContext context)
        {
            _context = context;
        }

        public void Create(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public IQueryable<T> FindAll(bool trackChanges) =>
            !trackChanges ? _context.Set<T>().AsNoTracking() : _context.Set<T>();

        public IQueryable<T> FindByCondition(Expression<Func<T,bool>> expression, bool trackChanges) =>
            !trackChanges ? _context.Set<T>().Where(expression).AsNoTracking() : _context.Set<T>().Where(expression);

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}