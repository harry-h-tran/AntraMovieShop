using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Contracts.Repository
{
    public interface IRepository<T> where T: class
    {
        T GetByID(int id);
        int Insert(T entity);
        int Update(T entity);
        int Delete(T entity);
        IEnumerable<T> GetAll();
    }
}
