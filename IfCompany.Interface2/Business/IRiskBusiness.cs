using IfCompanyTask.Entity.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IfCompany.Interface.Business
{
    public interface IRiskBusiness
    {
        Task<IList<Risk>> GetRisks();
        Task<Risk> GetRiskById(int id);

        Task<int> AddRisk(Risk inputEt);
        Task UpdateRisk(Risk inputEt);
        Task DeleteRisk(int id);
    }
}
