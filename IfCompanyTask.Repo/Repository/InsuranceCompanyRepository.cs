using IfCompany.Entity.Repository;
using IfCompany.Interface.Repository;
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
    public class InsuranceCompanyRepository : GenericRepository<InsuranceCompany>, IInsuranceCompanyRepository
    {
        private readonly IfDataContext _ifDBContext;
        public InsuranceCompanyRepository(IfDataContext context) : base(context)
        {
            _ifDBContext = context;
        }

        public async Task<IList<InsuranceCompany>> GetInsuranceCompanies()
        {
            return await this.GetAllAsync();
        }

        public async Task<InsuranceCompany> GetInsuranceCompanyById(int id)
        {
            return await this.GetByIdAsync(id);
        }

        public async Task<int> AddInsuranceCompany(InsuranceCompany inputEt)
        {
            inputEt.Id = 0;
            inputEt.CreatedDate = DateTime.Now;
            await this.InsertAsync(inputEt, true);
            //this.Commit();
            return inputEt.Id;
        }

        public async Task UpdateInsuranceCompany(InsuranceCompany inputEt)
        {
            //Get entity to be updated
            //Policy updEt = GetPolicyById(inputEt.PolicyId).Result;

            //if (!string.IsNullOrEmpty(inputEt.PolicyName)) updEt.PolicyName = inputEt.PolicyName;
            //if (!string.IsNullOrEmpty(inputEt.Phone)) updEt.Phone = inputEt.Phone;
            //if (!string.IsNullOrEmpty(inputEt.Email)) updEt.Email = inputEt.Email;
            //if (inputEt.PrimaryType != 0) updEt.PrimaryType = inputEt.PrimaryType;
            //updEt.AuditTime = DateTime.Now;

            await this.UpdateAsync(inputEt, true);
            //this.Commit();
        }

        public async Task DeleteInsuranceCompany(int id)
        {
            await this.DeleteAsync(id, true);
            //this.Commit();
        }
    }
}
