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
    public class PolicyAuditRepository : GenericRepository<PolicyAudit>, IPolicyAuditRepository
    {
        private readonly IfDataContext _ifDBContext;
        public PolicyAuditRepository(IfDataContext context) : base(context)
        {
            _ifDBContext = context;
        }
        public async Task<IList<PolicyAudit>> GetPolicyAudits()
        {
            return await this.GetAllAsync();
        }

        public async Task<PolicyAudit> GetPolicyAuditById(int id)
        {
            return await this.GetByIdAsync(id);
        }

        public async Task<PolicyAudit> AddPolicyAudit(PolicyAudit inputEt)
        {
            await this.InsertAsync(inputEt, true);
            return inputEt;
        }

        public async Task UpdatePolicyAudit(PolicyAudit inputEt)
        {
            await this.UpdateAsync(inputEt, true);
        }

        public async Task DeletePolicyAudit(int id)
        {
            await this.DeleteAsync(id, true);
        }

    }
}
