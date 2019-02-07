using IfCompanyTask.Entity.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace IfCompany.Entity
{
    public interface IInsuranceCompany
    {
        /// <summary>
        /// Name of Insurance company
        /// </summary>
        string Name { get; }
        /// <summary>
        /// List of the risks that can be insured. List can be updated at any time
        /// </summary>
        ICollection<Risk> AvailableRisks { get; set; }
   
    }
}
