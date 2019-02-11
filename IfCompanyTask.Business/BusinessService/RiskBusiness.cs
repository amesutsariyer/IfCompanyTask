using IfCompany.Interface.Business;
using IfCompanyTask.Entity.Repository;
using IfCompanyTask.Interface.Repository;
using IfCompanyTask.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IfCompanyTask.Business.BusinessService
{
    public class RiskBusiness : IRiskBusiness
    {
        private readonly IRiskRepository _riskRepository;
        public RiskBusiness(IRiskRepository riskRepository)
        {
            _riskRepository = riskRepository;
        }
        public async Task<IList<Risk>> GetRisks()
        {
            return await this._riskRepository.GetRisks();
        }

        public async Task<Risk> GetRiskById(int id)
        {
            return await this._riskRepository.GetRiskById(id);
        }

        public async Task<Risk> AddRisk(Risk inputEt)
        {
            return await this._riskRepository.AddRisk(inputEt);
        }

        public async Task UpdateRisk(Risk inputEt)
        {
            await this._riskRepository.UpdateRisk(inputEt);
        }

        public async Task DeleteRisk(int id)
        {
            await this._riskRepository.DeleteRisk(id);
        }
    }
}
