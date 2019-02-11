using IfCompanyTask.Entity.Model;
using IfCompanyTask.Entity.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IfCompanyTask.API.Model
{
    public class PolicyRequestModel
    {
        public int Id { get; set; }
        public  PolicyModel Policy { get; set; }
        public IList<Risk> Risk { get; set; }
        public DateTime ValidFrom { get; set; }
        public short ValidMonths { get; set; }
        public bool IsActive { get; set; }
    }
}
