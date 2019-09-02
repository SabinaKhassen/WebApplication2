using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataLayer.Repositories;

namespace DataLayer.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        Repository<Authors> AuthorUowRepository { get; }
        void Save();
        void BeginTransaction();
        void CommitTransaction();

    }
}