using IfCompanyTask.Entity.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IfCompany.Entity.Repository
{
    public class InsuranceCompany : BaseRepositoryEntity, IInsuranceCompany
    {
        public string Name { get; set; }

        public virtual ICollection<Risk> AvailableRisks { get; set; }
   
     
    }
}
