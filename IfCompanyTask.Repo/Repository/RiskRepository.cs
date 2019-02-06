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

        public async Task<int> AddRisk(Risk inputEt)
        {
            inputEt.Id = 0;
            inputEt.CreatedDate = DateTime.Now;
            await this.InsertAsync(inputEt, true);
            //this.Commit();
            return inputEt.Id;
        }

        public async Task UpdateRisk(Risk inputEt)
        {
            //Get entity to be updated
            //Risk updEt = GetRiskById(inputEt.RiskId).Result;

            //if (!string.IsNullOrEmpty(inputEt.RiskName)) updEt.RiskName = inputEt.RiskName;
            //if (!string.IsNullOrEmpty(inputEt.Phone)) updEt.Phone = inputEt.Phone;
            //if (!string.IsNullOrEmpty(inputEt.Email)) updEt.Email = inputEt.Email;
            //if (inputEt.PrimaryType != 0) updEt.PrimaryType = inputEt.PrimaryType;
            //updEt.AuditTime = DateTime.Now;

            await this.UpdateAsync(inputEt, true);
            //this.Commit();
        }

        public async Task DeleteRisk(int id)
        {
            await this.DeleteAsync(id, true);
            //this.Commit();
        }
    }
}
