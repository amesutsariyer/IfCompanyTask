using IfCompany.Entity.Repository;
using IfCompanyTask.Entity.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IfCompanyTask.Interface.Repository
{
    public interface IPolicyAuditRepository : IGenericRepository<PolicyAudit>
    {
        Task<IList<PolicyAudit>> GetPolicyAudits();
        Task<PolicyAudit> GetPolicyAuditById(int id);
        Task<PolicyAudit> AddPolicyAudit(PolicyAudit inputEt);
        Task UpdatePolicyAudit(PolicyAudit inputEt);
        Task DeletePolicyAudit(int id);
    }
}
