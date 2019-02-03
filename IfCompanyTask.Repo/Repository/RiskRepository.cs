using IfCompanyTask.Entity.Repository;
using IfCompanyTask.Interface.Repository;
using IfCompanyTask.Repository.DataContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace IfCompanyTask.Repository.Repository
{
    public class RiskRepository : GenericRepository<Risk>, IRiskRepository
    {
        private readonly IfDataContext _ifDBContext;
        public RiskRepository(IfDataContext context) : base(context)
        {
            _ifDBContext = context;
        }
    }
}
