using IfCompanyTask.Entity.Model;
using IfCompanyTask.Entity.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IfCompanyTask.API.Model
{
    public class RiskRequestModel
    {
        public int Id { get; set; }
        public PolicyModel Policy { get; set; }
        public Risk Risk { get; set; }
        public DateTime ValidFrom { get; set; }
        public short ValidMonths { get; set; }
        public bool IsActive { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime ValidTill { get; set; }
    }
}
