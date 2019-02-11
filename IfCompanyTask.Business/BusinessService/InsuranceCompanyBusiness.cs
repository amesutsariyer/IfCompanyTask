using IfCompany.Entity;
using IfCompany.Entity.Repository;
using IfCompany.Interface.Business;
using IfCompany.Interface.Repository;
using IfCompanyTask.Entity.Repository;
using IfCompanyTask.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IfCompanyTask.Business.BusinessService
{
    public class InsuranceCompanyBusiness : IInsuranceCompanyBusiness
    {
        private readonly IInsuranceCompanyRepository _insuranceCompanyRepository;
      

        public IList<Risk> AvailableRisks { get; set; }

        public InsuranceCompanyBusiness(IInsuranceCompanyRepository insuranceCompanyyRepository)
        {
            _insuranceCompanyRepository = insuranceCompanyyRepository;
          
        }
        public async Task<IList<InsuranceCompany>> GetInsuranceCompanies()
        {
            return await this._insuranceCompanyRepository.GetInsuranceCompanies();
        }

        public async Task<InsuranceCompany> GetInsuranceCompanyById(int id)
        {
            return await this._insuranceCompanyRepository.GetInsuranceCompanyById(id);
        }

        public async Task<InsuranceCompany> AddInsuranceCompanyAsync(InsuranceCompany inputEt)
        {
            return await this._insuranceCompanyRepository.AddInsuranceCompany(inputEt);
        }

        public async Task UpdateInsuranceCompany(InsuranceCompany inputEt)
        {
            await this._insuranceCompanyRepository.UpdateInsuranceCompany(inputEt);
        }

        public async Task DeleteInsuranceCompany(int id)
        {
            await this._insuranceCompanyRepository.DeleteInsuranceCompany(id);
        }

        
    }
}
