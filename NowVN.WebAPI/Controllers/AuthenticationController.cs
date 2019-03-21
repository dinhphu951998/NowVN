using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NowVN.Framework.CustomerLogic;
using NowVN.Framework.Helpers;
using NowVN.Framework.ViewModels;
using NowVN.Framework.ViewModels.EntityViewModel;

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

                return new AccessTokenResponse()
                {
                    Username = userAuthentication.Username,
                    AccessToken = accessToken
                };

            });
        }


        [Route("register")]
        [HttpPost]
        public dynamic Register(UserRegisterdViewModel userRegisterd)
        {
            return this.ExecuteInMonitoring( () =>
            {
                return customerLogic.CreateCustomer(userRegisterd).ToViewModel<CustomerViewModel>();
            });
        }



    }
}