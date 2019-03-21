using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NowVN.Framework.Helpers
{
    public class AppSettings
    {
        public string SecretKey { get; set; }

        public int TokenExpireTime { get; set; }
    }
}
