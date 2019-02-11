using IfCompanyTask.Entity.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace IfCompany.Entity
{
    public interface IPolicyAudit
    {
       int PolicyId { get; set; }
        Policy Policy { get; set; }
       DateTime ValidFrom { get; set; }
       short ValidMonths { get; set; }
       bool IsActive { get; set; }
       decimal Premium { get; set; }

    }
}
