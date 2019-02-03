using IfCompanyTask.Entity.Repository;
using IfCompanyTask.Interface.Repository;
using IfCompanyTask.Repository.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IfCompanyTask.Repository.Repository
{
    public class PolicyRepository : GenericRepository<Policy>, IPolicyRepository
    {
        private readonly IfDataContext _ifDBContext;
        public PolicyRepository(IfDataContext context) : base(context)
        {
            _ifDBContext = context;
        }
    }
}
