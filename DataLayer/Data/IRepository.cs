using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataLayer.Data
{
    public interface IRepository<T> where T: class
    {
        IEnumerable<T> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
        void Save();

    }
}