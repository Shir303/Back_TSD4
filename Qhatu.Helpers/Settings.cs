using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qhatu.Helpers
{
    public class Settings
    {
        public readonly string connectionString = string.Empty;
        public readonly string username = string.Empty;
        public readonly string password = string.Empty;
        public Settings()
        {
            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(),"appsettings.json");
            configurationBuilder.AddJsonFile(path,false);

            var root = configurationBuilder.Build();
            connectionString = root.GetSection("ConnectionStrings").GetSection("SqlConnection").Value;
            username = root.GetSection("User").GetSection("Username").Value;
            password = root.GetSection("User").GetSection("Password").Value;
        }
    }
}
