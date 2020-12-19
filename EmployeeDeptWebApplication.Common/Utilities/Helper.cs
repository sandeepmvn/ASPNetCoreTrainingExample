using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace EmployeeDeptWebApplication.Common
{
    public class Helper
    {
        private readonly IConfiguration _configuration;
        public Helper(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public T GetValues<T>(string key)
        {
            return (T)Convert.ChangeType(_configuration[key], typeof(T));
        }

        public string GetConnectionString(string key)
        {
            return _configuration.GetConnectionString(key);
        }


        public static T GetValues<T>(string key, IConfiguration configuration)
        {
            return (T)Convert.ChangeType(configuration[key], typeof(T));
        }

        public static string GetConnectionString(string key, IConfiguration configuration)
        {
            return configuration.GetConnectionString(key);
        }


       
    }
}
