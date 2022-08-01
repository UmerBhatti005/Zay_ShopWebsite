using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLibrary.Helper
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ShopContext _context;

        private DbSet<T> table;

        public GenericRepository()
        {
            _context = new ShopContext();
            table = _context.Set<T>();
        }

        public GenericRepository(ShopContext context)
        {
            _context = context;
            table = _context.Set<T>();
        }

        public IQueryable<T> GetAll()
        {
            return table.AsQueryable();
        }
        public IQueryable<T> GetById(int id)
        {
            return table.AsQueryable();
        }

        public IQueryable<T> GetByUsername(string username)
        {
            return table.AsQueryable();
        }

        public IQueryable<T> Insert(T obj)
        {
            table.Add(obj);
            _context.SaveChanges();
            return table.AsQueryable();
        }
        public IQueryable<T> Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
            return table.AsQueryable();
        }
        public void Delete(T obj)
        {
            //T found = table.Find(id);
            table.Remove(obj);
            _context.SaveChanges();
            //return obj;
        }
    }
}
