using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NowVN.Framework.CustomerLogic;
using NowVN.Framework.Helpers;
using NowVN.Framework.ViewModels;

namespace NowVN.API.Controllers
{
    [Route("api/[controller]")]
    public class AuthenticationController : NowVNController
    {
        private ICustomerLogic customerLogic;

        public AuthenticationController(ICustomerLogic customerLogic, ExtensionSettings extensionSettings) : base(extensionSettings)
        {
            this.customerLogic = customerLogic;
        }

        [Route("login")]
        [HttpPost]
        public ActionResult Login(UserAuthentication userAuthentication)
        {
            var accessToken = customerLogic.Authenticate(userAuthentication.Username, userAuthentication.Password);

            var tokenResponse = new AccessTokenResponse()
            {
                Username = userAuthentication.Username,
                AccessTokenString = accessToken
            };

            return Ok(tokenResponse);
        }



    }
}