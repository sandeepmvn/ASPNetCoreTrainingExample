using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebApplication.Utility
{
    public class Helper
    {
        public string AllowedHosts { get; set; }
        public ConnectionString ConnectionStrings { get; set; }
        public string Settings1 { get; set; }
        public List<string> Setting2 { get; set; }
    }

    public class ConnectionString
    {
        public string Default { get; set; }
        public string Default2 { get; set; }
    }


}
