using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_SDM_TESTES.Controllers
{
    [RoutePrefix("api/Validations")]
    public class Validations : ApiController
    {
        [AcceptVerbs("GET")]
        [Route("Testes")]
        public string Testes()
        {
            return "ok";
        }

    }
}
