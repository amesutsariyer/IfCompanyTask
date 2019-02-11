using IfCompanyTask.Entity.Repository;
using IfCompanyTask.Interface.Repository;
using IfCompanyTask.Repository.DataContext;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IfCompanyTask.Repository.Repository
{
    public class RiskRepository : GenericRepository<Risk>, IRiskRepository
    {
        private readonly IfDataContext _ifDBContext;
        public RiskRepository(IfDataContext context) : base(context)
        {
            _ifDBContext = context;
        }
        public async Task<IList<Risk>> GetRisks()
        {
            return await this.GetAllAsync();
        }

        public async Task<Risk> GetRiskById(int id)
        {
            return await this.GetByIdAsync(id);
        }

        public async Task<Risk> AddRisk(Risk inputEt)
        {
            await this.InsertAsync(inputEt, true);
            return inputEt;
        }

        public async Task UpdateRisk(Risk inputEt)
        {
            await this.UpdateAsync(inputEt, true);
        }

        public async Task DeleteRisk(int id)
        {
            await this.DeleteAsync(id, true);
        }
    }
}
