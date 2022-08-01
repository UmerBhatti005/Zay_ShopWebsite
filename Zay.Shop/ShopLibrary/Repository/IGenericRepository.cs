using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLibrary.Helper
{
    public interface IGenericRepository<T> where T : class 
    {
        IQueryable<T> GetAll();

        IQueryable<T> GetById(int id);

        IQueryable<T> GetByUsername(string username);

        IQueryable<T> Insert(T obj);

        IQueryable<T> Update(T obj);

        void Delete(T obj);

    }
}
