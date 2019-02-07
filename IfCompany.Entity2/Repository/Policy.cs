using IfCompany.Entity;
using IfCompany.Entity.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace IfCompanyTask.Entity.Repository
{
    public class Policy : BaseRepositoryEntity, IPolicy
    {
        public string NameOfInsuredObject { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTill { get; set; }
        public decimal Premium { get; set; }
        public virtual ICollection<Risk> InsuredRisks { get; set; }

        public int InsuranceCompanyId { get; set; }
        public virtual InsuranceCompany InsuranceCompany { get; set; }

    }
}
