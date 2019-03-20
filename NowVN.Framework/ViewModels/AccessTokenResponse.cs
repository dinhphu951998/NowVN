using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NowVN.Framework.ViewModels
{
    public class AccessTokenResponse
    {
        public string Username { get; set; }

        //public string Fullname { get; set; }

        public string AccessTokenString { get; set; }

    }
}
