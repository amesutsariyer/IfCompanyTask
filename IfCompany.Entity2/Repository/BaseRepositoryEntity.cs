using System;
using System.Collections.Generic;
using System.Text;

namespace IfCompanyTask.Entity.Repository
{
    public abstract class BaseRepositoryEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
