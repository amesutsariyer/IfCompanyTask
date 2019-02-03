using IfCompanyTask.Common.Helper;
using IfCompanyTask.Entity.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IfCompanyTask.Repository.DataContext
{
    public static class StoreDataInitializer
    {
        public static void Initialize(IfDataContext context)
        {
            if (StaticConfigs.GetConfig("UseInMemoryDatabase") != "true")
            {
                context.Database.EnsureCreated();
            }

            if (context.Policies.Any())
            {
                return;
            }

            var statusTypes = new Risk[]
            {
                new Risk {Name="Risk1",YearlyPrice=100},
                new Risk {Name="Risk2",YearlyPrice=100},
              
            };
            context.Risks.AddRange(statusTypes);
            context.SaveChanges();
            
        }
    }
}
