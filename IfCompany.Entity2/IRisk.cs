using System;
using System.Collections.Generic;
using System.Text;

namespace IfCompany.Entity
{
    public interface IRisk
    {
        /// <summary>
        /// Unique name of the risk
        /// </summary>
         string Name { get; set; }
        /// <summary>
        /// Risk yearly price
        /// </summary>
         decimal YearlyPrice { get; set; }
    }
}
