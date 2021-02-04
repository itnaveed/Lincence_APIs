using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.DataRepository
{
    public interface IHelper<TEntity>
    {
        IEnumerable<TEntity> ExecuteQuery(string entity);
    }
}
