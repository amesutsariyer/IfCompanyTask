using IfCompanyTask.Entity.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IfCompanyTask.Interface.Repository
{
    public interface IPolicyRepository : IGenericRepository<Policy>
    {
        Task<IList<Policy>> GetPolicies();
        Task<Policy> GetPolicyById(int id);

        Task<int> AddPolicy(Policy inputEt);
        Task UpdatePolicy(Policy inputEt);
        Task DeletePolicy(int id);
    }
}
