using IfCompany.Interface.Business;
using IfCompanyTask.Entity.Repository;
using IfCompanyTask.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IfCompanyTask.Business.BusinessService
{
    public class PolicyBusiness : IPolicyBusiness
    {
        private readonly IPolicyRepository _policyRepository;
        public PolicyBusiness(IPolicyRepository policyRepository)
        {
            _policyRepository = policyRepository;
        }
        public async Task<IList<Policy>> GetPolicies()
        {
            return await this._policyRepository.GetPolicies();
        }

        public async Task<Policy> GetPolicyById(int id)
        {
            return await this._policyRepository.GetPolicyById(id);
        }

        public async Task<Policy> AddPolicy(Policy inputEt)
        {
            return await this._policyRepository.AddPolicy(inputEt);
        }

        public async Task UpdatePolicy(Policy inputEt)
        {
            await this._policyRepository.UpdatePolicy(inputEt);
        }

        public async Task DeletePolicy(int id)
        {
            await this._policyRepository.DeletePolicy(id);
        }

        public async Task<Policy> GetPolicyByName(string name)
        {
            return await _policyRepository.GetPolicyByName(name);
        }
    }
}
