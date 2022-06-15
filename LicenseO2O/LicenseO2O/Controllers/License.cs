using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LicenseO2O.Models;

namespace LicenseO2O.Controllers
{
    [Route("api/License")]
    [ApiController]
    public class License : ControllerBase
    {

        [AcceptVerbs("GET")]
        [Route("GetLicense")]
        public Licenses GetLicense()
        {
            Licenses licenses = new Licenses();
            Connector connector = new Connector();
            connector.Nome = "Excel";
            licenses.Connectors = connector;
            


            return licenses;
        }


    }
}
