using IfCompanyTask.Entity.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace IfCompany.Entity.Repository
{
    public class PolicyAudit : BaseRepositoryEntity,IPolicyAudit
    {
        public int PolicyId { get; set; }
        public virtual Policy Policy { get; set; }
        public DateTime ValidFrom { get; set; }
        public short ValidMonths { get; set; }
        public DateTime ValidTill { get; set; }
        public bool IsActive { get; set; }
        public decimal Premium{ get; set; }
    }
}
