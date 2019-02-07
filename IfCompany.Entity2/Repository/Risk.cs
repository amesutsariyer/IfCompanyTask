using IfCompany.Entity;
using IfCompany.Entity.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace IfCompanyTask.Entity.Repository
{
    public class Risk : BaseRepositoryEntity, IRisk
    {

        public string Name { get; set; }
        public decimal YearlyPrice { get; set; }

        public int? PolicyId { get; set; }
        public virtual Policy Policy { get; set; }

        public int InsuranceCompanyId { get; set; }
        public virtual InsuranceCompany InsuranceCompany { get; set; }

    }
}
