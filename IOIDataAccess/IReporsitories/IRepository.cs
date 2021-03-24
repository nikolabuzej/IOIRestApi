using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace IOIDataAccess.IReporsitories
{
  public  interface IRepository<T>
    {
        void Add(T item);
        List<T> GetAll();
        T FindById(int id);
        void Delete(T item);
        List<T> Search(Expression<Func<T, bool>> pred);

    }
}
