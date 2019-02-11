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

        public async Task<InsuranceCompany> AddInsuranceCompany(InsuranceCompany inputEt)
        {
            await this.InsertAsync(inputEt, true);
            return inputEt;
        }

        public async Task UpdateInsuranceCompany(InsuranceCompany inputEt)
        {
            await this.UpdateAsync(inputEt, true);
        }

        public async Task DeleteInsuranceCompany(int id)
        {
            await this.DeleteAsync(id, true);
        }
    }
}
