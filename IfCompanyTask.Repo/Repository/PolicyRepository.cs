using IfCompanyTask.Entity.Repository;
using IfCompanyTask.Interface.Repository;
using IfCompanyTask.Repository.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IfCompanyTask.Repository.Repository
{
    public class PolicyRepository : GenericRepository<Policy>, IPolicyRepository
    {
        private readonly IfDataContext _ifDBContext;
        public PolicyRepository(IfDataContext context) : base(context)
        {
            _ifDBContext = context;
        }

        public async Task<IList<Policy>> GetPolicies()
        {
            return await this.GetAllAsync();
        }

        public async Task<Policy> GetPolicyById(int id)
        {
            return await this.GetByIdAsync(id);
        }

        public async Task<Policy> AddPolicy(Policy inputEt)
        {
            await this.InsertAsync(inputEt, true);
            return inputEt;
        }

        public async Task UpdatePolicy(Policy inputEt)
        {
            await this.UpdateAsync(inputEt, true);
        }

        public async Task DeletePolicy(int id)
        {
            await this.DeleteAsync(id, true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="effectiveDate"></param>
        /// <returns></returns>
        public async Task<Policy> GetPolicyByName(string name)
        {
                return await this.FindAsync(x => x.NameOfInsuredObject.Trim().ToLower() == name.Trim().ToLower());
        }
    }
}
