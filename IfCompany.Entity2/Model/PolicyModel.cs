using IfCompanyTask.Entity.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace IfCompanyTask.Entity.Model
{
    public class PolicyModel : BaseRepositoryEntity
    {
        public string NameOfInsuredObject { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTill { get; set; }
        public decimal Premium { get; set; }
        public int InsuranceCompanyId { get; set; }
       
    }
}
