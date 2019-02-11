using IfCompany.Entity;
using IfCompany.Entity.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IfCompanyTask.Entity.Repository
{
    public class Policy : BaseRepositoryEntity, IPolicy
    {
        public Policy()
        {
            InsuredRisks = new List<Risk>();
        }
        public string NameOfInsuredObject { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTill { get; set; }
        public decimal Premium { get; set; }


        //public int InsuranceCompanyId { get; set; }
        //public virtual InsuranceCompany InsuranceCompany { get; set; }
        [NotMapped]
        public virtual IList<Risk> InsuredRisks { get; set; }

    }
}
