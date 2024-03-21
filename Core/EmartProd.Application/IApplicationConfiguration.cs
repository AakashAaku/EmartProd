using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace EmartProd.Application
{
    public class IApplicationConfiguration
    {
        public static void RegisterApplicationConfig(IServiceCollection service)
        {
           service.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}