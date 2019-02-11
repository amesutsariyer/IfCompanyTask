using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IfCompany.Entity;
using IfCompany.Entity.Model;
using IfCompany.Entity.Repository;
using IfCompany.Interface.Business;
using IfCompanyTask.API.Model;
using IfCompanyTask.Common.Classes;
using IfCompanyTask.Entity.Repository;
using Microsoft.AspNetCore.Mvc;

namespace IfCompanyTask.API.Controllers
{
    public class CompanyController : BaseController
    {
        private readonly IInsuranceCompanyBusiness _compBusiness;
        private readonly IRiskPolicyAuditBusiness _riskPolicyAuditBusiness;


        private readonly IAutoMapConverter<InsuranceCompany, InsuranceCompanyModel> _mapEntityToModel;
        private readonly IAutoMapConverter<InsuranceCompanyModel, InsuranceCompany> _mapModelToEntity;
        public CompanyController(IInsuranceCompanyBusiness compBusiness, IAutoMapConverter<InsuranceCompany, InsuranceCompanyModel> mapEntityToModel, IAutoMapConverter<InsuranceCompanyModel, InsuranceCompany> mapModelToEntity, IRiskPolicyAuditBusiness riskPolicyAuditBusiness)
        {
            _compBusiness = compBusiness;
            _mapEntityToModel = mapEntityToModel;
            _mapModelToEntity = mapModelToEntity;
            _riskPolicyAuditBusiness = riskPolicyAuditBusiness;
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
        public async Task<InsuranceCompany> Post([FromBody] InsuranceCompanyModel model)
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
        public async Task Delete(int id)
        {
            await _compBusiness.DeleteInsuranceCompany(id);
        }
        [HttpGet("Task/GetAllRisk")]
        public IList<Risk> GetAllRisk()
        {
            return _riskPolicyAuditBusiness.AvailableRisks;
        }
        [HttpPost("Task/RemoveRisk")]
        public void RemoveRisk(RiskRequestModel model)
        {
            _riskPolicyAuditBusiness.RemoveRisk(model.Policy.NameOfInsuredObject, model.Risk, model.ValidTill, model.EffectiveDate);
        }
        [HttpPost("Task/AddRisk")]
        public void AddRisk(RiskRequestModel model)
        {
            _riskPolicyAuditBusiness.AddRisk(model.Policy.NameOfInsuredObject, model.Risk, model.ValidFrom, model.EffectiveDate);
        }
        [HttpGet("Task/GetPolicy/{nameOfInsuredObject}/{effectiveDate}")]
        public IPolicy GetPolicy(string nameOfInsuredObject, DateTime effectiveDate)
        {
            return _riskPolicyAuditBusiness.GetPolicy(nameOfInsuredObject, effectiveDate);
        }
        [HttpPost("Task/SellPolicy")]
        public IPolicy SellPolicy(PolicyRequestModel model)
        {
            return _riskPolicyAuditBusiness.SellPolicy(model.Policy.NameOfInsuredObject, model.ValidFrom, model.ValidMonths, model.Risk);
        }
    }
}