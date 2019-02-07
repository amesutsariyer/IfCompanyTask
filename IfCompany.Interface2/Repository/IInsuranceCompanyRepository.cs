using IfCompany.Entity.Repository;
using IfCompanyTask.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IfCompany.Interface.Repository
{
    public interface IInsuranceCompanyRepository : IGenericRepository<InsuranceCompany>
    {
        Task<IList<InsuranceCompany>> GetInsuranceCompanies();
        Task<InsuranceCompany> GetInsuranceCompanyById(int id);
        Task<int> AddInsuranceCompany(InsuranceCompany inputEt);
        Task UpdateInsuranceCompany(InsuranceCompany inputEt);
        Task DeleteInsuranceCompany(int id);
    }
}
