using IfCompany.Entity.Repository;
using IfCompanyTask.Entity.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IfCompanyTask.Interface.Repository
{
    public interface IRiskPolicyAuditRepository : IGenericRepository<RiskPolicyAudit>
    {
        Task<IList<RiskPolicyAudit>> GetRiskPolicyAudits();
        Task<RiskPolicyAudit> GetRiskPolicyAuditById(int id);
        Task<RiskPolicyAudit> AddRiskPolicyAudit(RiskPolicyAudit inputEt);
        Task UpdateRiskPolicyAudit(RiskPolicyAudit inputEt);
        Task DeleteRiskPolicyAudit(int id);
    }
}
