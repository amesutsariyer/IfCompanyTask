using IfCompany.Entity;
using IfCompany.Entity.Model;
using IfCompany.Entity.Repository;
using IfCompanyTask.Entity.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IfCompany.Interface.Business
{
    public interface IInsuranceCompanyBusiness
    {
        Task<IList<InsuranceCompany>> GetInsuranceCompanies();
        Task<InsuranceCompany> GetInsuranceCompanyById(int id);

        Task<InsuranceCompany> AddInsuranceCompanyAsync(InsuranceCompany inputEt);
        Task UpdateInsuranceCompany(InsuranceCompany inputEt);
        Task DeleteInsuranceCompany(int id);

     
    }
}
