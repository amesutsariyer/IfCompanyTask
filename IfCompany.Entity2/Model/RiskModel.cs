using System;
using System.Collections.Generic;
using System.Text;

namespace IfCompanyTask.Entity.Model
{
    public class RiskModel
    {
        /// <summary>
        /// Unique name of the risk
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Risk yearly price
        /// </summary>
        public decimal YearlyPrice { get; set; }
    }
}
