using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication2.Data;

namespace WebApplication2.Repositories
{
    public class AuthorRepository : IRepository<Authors>
    {
        private readonly Model1 db;
        public AuthorRepository()
        {
            db = new Model1();
        }
        public AuthorRepository(Model1 db)
        {
            this.db = db;
        }
        public void Add(Authors entity)
        {
            db.Authors.Add(entity);
        }

        public void Delete(int id)
        {
            Authors authors = db.Authors.Find(id);
            db.Authors.Remove(authors);
        }

        public void Update(Authors entity)
        {
            db.Entry(entity).State = EntityState.Modified;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public IEnumerable<Authors> GetAll()
        {
             return db.Authors.ToList();
        }
    }
}