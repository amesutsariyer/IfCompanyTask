using IfCompanyTask.Entity.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace IfCompany.Entity.Repository
{
    public class RiskPolicyAudit : BaseRepositoryEntity
    {
        public int PolicyAuditId { get; set; }
        public virtual PolicyAudit Policy { get; set; }
        public virtual Risk Risk { get; set; }

        public int RiskId { get; set; }
        public DateTime ValidFrom { get; set; }
        // public DateTime EffectiveDate{ get; set; }
        //public short ValidMonths { get; set; }
        public bool IsActive { get; set; }
    }
}
