using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IfCompany.Interface.Business;
using IfCompanyTask.Common.Classes;
using IfCompanyTask.Entity.Model;
using IfCompanyTask.Entity.Repository;
using Microsoft.AspNetCore.Mvc;

namespace IfCompanyTask.API.Controllers
{
    public class PolicyController : BaseController
    {
        private readonly IPolicyBusiness _policyBusiness;
        private readonly IAutoMapConverter<Policy, PolicyModel> _mapEntityToModel;
        private readonly IAutoMapConverter<PolicyModel, Policy> _mapModelToEntity;
        public PolicyController(IPolicyBusiness policyBusiness, IAutoMapConverter<Policy, PolicyModel> mapEntityToModel, IAutoMapConverter<PolicyModel, Policy> mapModelToEntity)
        {
            _policyBusiness = policyBusiness;
            _mapEntityToModel = mapEntityToModel;
            _mapModelToEntity = mapModelToEntity;
        }
        [HttpGet]
        public async Task<IList<Policy>> Get()
        {
            return await _policyBusiness.GetPolicies();
        }

        [HttpGet("{id}")]
        public async Task<Policy> Get(int id)
        {
            return await _policyBusiness.GetPolicyById(id);
        }

        [HttpPost]
        public async Task<Policy> Post([FromBody] PolicyModel model)
        {
            var entity = _mapModelToEntity.ConvertObject(model);
            return await _policyBusiness.AddPolicy(entity);
        }

        [HttpPut]
        public async Task Put([FromBody] PolicyModel model)
        {
            var entity = _mapModelToEntity.ConvertObject(model);
            await _policyBusiness.UpdatePolicy(entity);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _policyBusiness.DeletePolicy(id);
        }
    }
}