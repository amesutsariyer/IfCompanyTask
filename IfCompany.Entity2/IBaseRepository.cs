using System;
using System.Collections.Generic;
using System.Text;

namespace IfCompany.Entity
{
    public interface IBaseRepository
    {
         int Id { get; set; }
         DateTime? CreatedDate { get; set; }
         DateTime? ModifiedDate { get; set; }
    }
}
