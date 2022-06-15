using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using O2OUI.Conectores.Strings.Models;

namespace O2OUI.Conectores.Strings.Controllers
{
    [RoutePrefix("api/Strings")]
    public class StringsController : ApiController
    {

        [AcceptVerbs("GET")]
        [Route("Substring")]
        public string SubStringMethod(string text, int startIndex, int lengthIndex)
        {
            string retorno;
            retorno = text.Substring(startIndex, lengthIndex);

            return retorno;
        }

        [AcceptVerbs("GET")]
        [Route("StringLength")]
        public int StringLength(string text)
        {
            return text.Length;
        }

        [AcceptVerbs("POST")]
        [Route("StringReplace")]
        public string StringReplace(SubstringObject substringObject)
        {
            string text = substringObject.TextOld;
            return text.Replace(substringObject.ValueReplace, substringObject.ValueNew);
        }

        [AcceptVerbs("GET")]
        [Route("StringTrim")]
        public string StringTrim(string text, char TrimText)
        {
            return text.Trim(TrimText);
        }


    }
}
