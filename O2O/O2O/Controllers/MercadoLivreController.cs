using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace O2O.Controllers
{
    [RoutePrefix("api/MercadoLivre")]
    public class MercadoLivreController : ApiController
    {

        [AcceptVerbs("GET")]
        [Route("getHoje")]
        public string getHoje()
        {
            return DateTime.Now.DayOfWeek.ToString();
        }
    }
}
