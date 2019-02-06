using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IfCompany.Interface.Business;
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
        // GET all risks
        [HttpGet]
        public async Task<IList<Risk>> Get()
        {
            return await _riskBusiness.GetRisks();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
