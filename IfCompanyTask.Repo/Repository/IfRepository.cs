using IfCompany.Interface.Repository;
using IfCompanyTask.Repository.DataContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace IfCompanyTask.Repository.Repository
{
    public class IfRepository<T> : GenericRepository<T>, IIFRepository<T> where T : class
    {
        //Just need to pass db context to GenericRepository. 
        public IfRepository(IfDataContext context) : base(context)
        {
        }
    }
}
