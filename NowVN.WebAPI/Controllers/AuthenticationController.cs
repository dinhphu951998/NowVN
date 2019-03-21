using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NowVN.Framework.CustomerLogic;
using NowVN.Framework.Helpers;
using NowVN.Framework.ViewModels;

namespace NowVN.WebAPI.Controllers
{
    [Route("api")]
    public class AuthenticationController : NowVNController
    {
        private ICustomerLogic customerLogic;

        public AuthenticationController(ICustomerLogic customerLogic, ExtensionSettings extensionSettings) : base(extensionSettings)
        {
            this.customerLogic = customerLogic;
        }

        [Route("login")]
        [HttpPost]
        public dynamic Login(UserAuthentication userAuthentication)
        {
            return ExecuteInMonitoring(() =>
            {
                var accessToken = customerLogic.Authenticate(userAuthentication.Username, userAuthentication.Password);

                var tokenResponse = new AccessTokenResponse()
                {
                    Username = userAuthentication.Username,
                    AccessToken = accessToken
                };

                return BaseResponse.GetSuccessResponse(tokenResponse);
            });
        }


        [Route("register")]
        [HttpPost]
        public dynamic Register(UserRegisterdViewModel userRegisterd)
        {
            return this.ExecuteInMonitoring( () =>
            {
                var result = customerLogic.CreateCustomer(userRegisterd);
                return BaseResponse.GetSuccessResponse(result);
                
            });
        }



    }
}