using IfCompany.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace IfCompanyTask.Entity.Repository
{
    public abstract class BaseRepositoryEntity:IBaseRepository
    {
        public int Id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
