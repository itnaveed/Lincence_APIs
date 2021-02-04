using System;
using System.Collections.Generic;
using System.Text;
using ViewModels;

namespace Repositories.DataRepository
{
    public interface IDataRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> customQuery(string entity);
        IEnumerable<AllowedServicesVM> RawQuery(string entity);
        IEnumerable<UserServicesVM> userServices(string entity);
        TEntity Get(Guid id);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
