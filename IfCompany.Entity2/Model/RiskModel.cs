using IfCompany.Entity;
using IfCompanyTask.Entity.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace IfCompanyTask.Entity.Model
{
    public struct RiskModel : IBaseRepository
    {
        /// <summary>
        /// Unique name of the risk
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Risk yearly price
        /// </summary>
        public decimal YearlyPrice { get; set; }

        public int? PolicyId { get; set; }
        public int InsuranceCompanyId { get; set; }
        public int Id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
