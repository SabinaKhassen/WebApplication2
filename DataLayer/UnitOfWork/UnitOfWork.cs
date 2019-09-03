using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataLayer.Repositories;
using System.Data.Entity;

namespace DataLayer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext db;
        private bool disposed = false;

        Repository<Authors> _authorUowRepository;
        public Repository<Authors> AuthorUowRepository
        {
            get
            {
                return _authorUowRepository == null ? new Repository<Authors>(db) : _authorUowRepository;
            }
        }
        public UnitOfWork(DbContext model)
        {
            this.db = model;
            db.Database.CommandTimeout = 180;
        }

        public void BeginTransaction()
        {
            db.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            db.Database.CurrentTransaction.Commit();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if(!this.disposed)
            {
                if(disposing)
                {
                    if (db != null)
                        db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}