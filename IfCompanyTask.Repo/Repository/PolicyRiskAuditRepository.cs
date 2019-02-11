using IfCompany.Entity.Repository;
using IfCompanyTask.Entity.Repository;
using IfCompanyTask.Interface.Repository;
using IfCompanyTask.Repository.DataContext;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IfCompanyTask.Repository.Repository
{
    public class PolicyRiskAuditRepository : GenericRepository<RiskPolicyAudit>, IRiskPolicyAuditRepository
    {
        private readonly IfDataContext _ifDBContext;
        public PolicyRiskAuditRepository(IfDataContext context) : base(context)
        {
            _ifDBContext = context;
        }
        public async Task<IList<RiskPolicyAudit>> GetRiskPolicyAudits()
        {
            return await this.GetAllAsync();
        }

        public async Task<RiskPolicyAudit> GetRiskPolicyAuditById(int id)
        {
            return await this.GetByIdAsync(id);
        }

        public async Task<RiskPolicyAudit> AddRiskPolicyAudit(RiskPolicyAudit inputEt)
        {
            await this.InsertAsync(inputEt, true);
            return inputEt;
        }

        public async Task UpdateRiskPolicyAudit(RiskPolicyAudit inputEt)
        {
            await this.UpdateAsync(inputEt, true);
        }

        public async Task DeleteRiskPolicyAudit(int id)
        {
            await this.DeleteAsync(id, true);
        }


    }
}
