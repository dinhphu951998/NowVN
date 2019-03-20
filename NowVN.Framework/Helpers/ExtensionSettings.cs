using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NowVN.Framework.Helpers
{
    public class ExtensionSettings
    {
        public IConfiguration configuration { get; private set; }
        public AppSettings appSettings { get; private set; }

        public ExtensionSettings(IConfiguration configuration, AppSettings appSettings)
        {
            this.configuration = configuration;
            this.appSettings = appSettings;
        }
    }
}
