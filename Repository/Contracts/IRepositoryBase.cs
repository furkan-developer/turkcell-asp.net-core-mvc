using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repository.Contracts
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll(bool isTrack);
        T? FindByCondition(bool isTrack, Expression<Func<T,bool>> expression);
        void Insert(T product);
    }
}