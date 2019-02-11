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

    public class RiskController : BaseController
    {
        private readonly IRiskBusiness _riskBusiness;
        public RiskController(IRiskBusiness riskBusiness)
        {
            _riskBusiness = riskBusiness;
        }
        [HttpGet]
        public async Task<IList<Risk>> Get()
        {
            return await _riskBusiness.GetRisks();
        }

        [HttpGet("{id}")]
        public async Task<Risk> Get(int id)
        {
            return await _riskBusiness.GetRiskById(id);
        }

        [HttpPost]
        public async Task<Risk> Post([FromBody] RiskModel model)
        {

            var entity = new Risk() { YearlyPrice = model.YearlyPrice,  Name = model.Name };
           

            return await _riskBusiness.AddRisk(entity);
        }

        [HttpPut]
        public async Task Put([FromBody] RiskModel model)
        {
            var entity = new Risk() { Id = model.Id, YearlyPrice = model.YearlyPrice,Name = model.Name,CreatedDate=model.CreatedDate };
            await _riskBusiness.UpdateRisk(entity);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _riskBusiness.DeleteRisk(id);
        }
    }
}
