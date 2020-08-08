using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hma.Core.Interfaces
{
	public interface IRepository<T>
	{
        IQueryable<T> AsQueryable();
        void Insert(T entity);
        void Delete(int id);
        int SaveChanges();
        T Find(params object[] keyValues);
        void Dispose();
    }
}
