using IfCompanyTask.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace IfCompany.Interface.Repository
{
    public interface IIFRepository<TEntity>: IGenericRepository<TEntity> where TEntity : class
    {
      
    }
}
