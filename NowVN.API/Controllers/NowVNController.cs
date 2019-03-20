using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NowVN.Framework.Helpers;
using NowVN.Framework.Models;
using NowVN.Framework.ProductLogic;

namespace NowVN.API.Controllers
{
    [ApiController]
    public class NowVNController : ControllerBase
    {
        private ExtensionSettings extensionSettings;

        public NowVNController(ExtensionSettings extensionSettings)
        {
            this.extensionSettings = extensionSettings;
        }

    }
}