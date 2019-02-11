using IfCompanyTask.Entity.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IfCompanyTask.Interface.Repository
{
    public interface IRiskRepository :IGenericRepository<Risk> 
    {
        Task<IList<Risk>> GetRisks();
        Task<Risk> GetRiskById(int id);
        Task<Risk> AddRisk(Risk inputEt);
        Task UpdateRisk(Risk inputEt);
        Task DeleteRisk(int id);
    }
}
