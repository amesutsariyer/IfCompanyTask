using System;
using System.Collections.Generic;
using System.Text;

namespace IfCompany.Entity
{
    public interface ILogResourceAPI
    {
        string Message { get; set; }
        string MessageTemplate { get; set; }
        string Level { get; set; }
        DateTime TimeStamp { get; set; }
        string Exception { get; set; }
        string Properties { get; set; }
    }
}
