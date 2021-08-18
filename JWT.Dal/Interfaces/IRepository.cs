using System;
using System.Collections.Generic;
using System.Text;

namespace JWT.Dal.Interfaces
{
    public interface IRepository<TEntity, TKey> where TEntity : new()
    {
        TKey Insert(TEntity entity);

        TEntity Get(TKey Id);
        IEnumerable<TEntity> GetAll();

        bool Update(TEntity entity);
        bool Delete(TKey Id);
    }
}
