using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Repository.Contracts;
using Repository.EfCore;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Repository.Concrete
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T>
        where T : class, new()
    {
        protected readonly AppDbContext _context;

        protected RepositoryBase(AppDbContext context)
        {
            _context = context;
        }

        public IQueryable<T> FindAll(bool isTrack)
        {
            return isTrack 
            ? _context.Set<T>().AsQueryable()
            : _context.Set<T>().AsNoTracking();
        }

        public T? FindByCondition(bool isTrack, Expression<Func<T,bool>> expression)
        {
            return isTrack 
            ? _context.Set<T>().SingleOrDefault(expression)
            : _context.Set<T>().AsNoTracking().SingleOrDefault(expression);
        }

        public void Insert(T product)
        {
            _context.Add<T>(product);
        }

        public void Modify(T entity)
        {
            _context.Update(entity);
        }
    }
}