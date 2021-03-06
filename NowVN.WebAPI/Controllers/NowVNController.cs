﻿using Microsoft.AspNetCore.Mvc;
using NowVN.Framework;
using NowVN.Framework.Helpers;
using NowVN.Framework.ViewModels;
using System;

namespace NowVN.WebAPI.Controllers
{
    [ApiController]
    public class NowVNController : ControllerBase
    {
        private ExtensionSettings extensionSettings;

        public string CurrentUserId
        {
            get
            {
                return HttpContext.User?.FindFirst(ClaimTypes.UserId)?.Value;
            }
        }

        public string CurrentUsername
        {
            get
            {
                return HttpContext.User?.FindFirst(ClaimTypes.Username)?.Value;
            }
        }

        public NowVNController(ExtensionSettings extensionSettings)
        {
            this.extensionSettings = extensionSettings;
        }

        protected dynamic ExecuteInMonitoring(Func<dynamic> function)
        {
            dynamic result;
            try
            {
                result =  function();
                
            }catch(NowVNException ex)
            {
                return BaseResponse.GetErrorResponse(ex.Message);
            }
            return BaseResponse.GetSuccessResponse(result);
        } 

    }
}