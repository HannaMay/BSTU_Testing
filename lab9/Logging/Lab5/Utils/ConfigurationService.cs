using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Lab5.Utils
{
    class ConfigurationService
    {
        public static IConfigurationRoot GetIConfigurationRoot()
        {
            return new ConfigurationBuilder()
                .AddJsonFile("appsettings.DEV.json", optional: true)
                .AddEnvironmentVariables()
                .Build();
        }
    }
}
