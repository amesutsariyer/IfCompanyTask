using IfCompanyTask.Entity.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IfCompany.Interface.Business
{
    public interface IPolicyBusiness
    {
        Task<IList<Policy>> GetPolicies();
        Task<Policy> GetPolicyById(int id);
        Task<Policy> GetPolicyByName(string name);

        Task<Policy> AddPolicy(Policy inputEt);
        Task UpdatePolicy(Policy inputEt);
        Task DeletePolicy(int id);
    }
}
