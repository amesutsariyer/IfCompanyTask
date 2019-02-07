using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IfCompany.Entity.Model;
using IfCompany.Entity.Repository;
using IfCompany.Interface.Business;
using IfCompanyTask.Common.Classes;
using Microsoft.AspNetCore.Mvc;

namespace IfCompanyTask.API.Controllers
{
    public class CompanyController : BaseController
    {
        private readonly IInsuranceCompanyBusiness _compBusiness;
        private readonly IAutoMapConverter<InsuranceCompany, InsuranceCompanyModel> _mapEntityToModel;
        private readonly IAutoMapConverter<InsuranceCompanyModel, InsuranceCompany> _mapModelToEntity;
        public CompanyController(IInsuranceCompanyBusiness compBusiness, IAutoMapConverter<InsuranceCompany, InsuranceCompanyModel> mapEntityToModel, IAutoMapConverter<InsuranceCompanyModel, InsuranceCompany> mapModelToEntity)
        {
            _compBusiness = compBusiness;
            _mapEntityToModel = mapEntityToModel;
            _mapModelToEntity = mapModelToEntity;
        }
        // GET all risks
        [HttpGet]
        public async Task<IList<InsuranceCompany>> Get()
        {
            return await _compBusiness.GetInsuranceCompanies();
        }

        [HttpGet("{id}")]
        public async Task<InsuranceCompany> Get(int id)
        {
            return await _compBusiness.GetInsuranceCompanyById(id);
        }

        [HttpPost]
        public async Task<int> Post([FromBody] InsuranceCompanyModel model)
        {
            var entity = _mapModelToEntity.ConvertObject(model);
            return await _compBusiness.AddInsuranceCompanyAsync(entity);
        }

        [HttpPut]
        public async void Put([FromBody] InsuranceCompanyModel model)
        {
            var entity = _mapModelToEntity.ConvertObject(model);
            await _compBusiness.UpdateInsuranceCompany(entity);
        }

        [HttpDelete("{id}")]
        public async void Delete(int id)
        {
            await _compBusiness.DeleteInsuranceCompany(id);
        }
    }
}