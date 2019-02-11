using IfCompanyTask.Entity.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace IfCompany.Entity.Repository
{
    public class LogResourceAPI : BaseRepositoryEntity, ILogResourceAPI
    {
        public string Message { get; set; }
        public string MessageTemplate { get; set; }
        public string Level { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Exception { get; set; }
        public string Properties { get; set; }
    }
}
