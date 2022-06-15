using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace O2O.Controllers
{
    [RoutePrefix("api/NumberFunctions")]
    public class NumberFunctionsController : ApiController
    {

        [AcceptVerbs("GET")]
        [Route("average")]
        public decimal getMedia(decimal[] valores)
        {
            
            int tamanho = valores.Length;
            decimal soma=0;
            for(int i= 0; i<tamanho; i++)
            {
                soma = soma + valores[i];
            }

            decimal media;
            media = soma / tamanho;

            return media;
        }

        [AcceptVerbs("GET")]
        [Route("Sum")]
        public decimal getSum(decimal[] valores)
        {
            int tamanho = valores.Length;
            decimal soma = 0;
            for (int i = 0; i < tamanho; i++)
            {
                soma = soma + valores[i];
            }
            return soma;
        }


        [AcceptVerbs("GET")]
        [Route("Count")]
        public int getCount(decimal[] valores) 
        {
            return valores.Length;
        }





    }
}
