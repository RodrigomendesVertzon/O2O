using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using O2OUI.Conectores.DateAndTime.Models;
using System.Web.Http;

namespace O2OUI.Conectores.DateAndTime.Controllers
{
    [RoutePrefix("api/DateAndTime")]
    public class DateAndTimeController : ApiController
    {
        /// <summary>
        /// Método de retorno da data atual
        /// </summary>
        [AcceptVerbs("GET")]
        [Route("getDateNow")]
        public Hoje getHoje()
        {

            Hoje hj = new Hoje();
            hj.Ano = DateTime.Now.Year;
            hj.Dia = DateTime.Now.Day;
            hj.DiaSemana = DateTime.Now.DayOfWeek;
            hj.Mes = DateTime.Now.Month;
            hj.Hora = DateTime.Now.Hour;
            hj.Minuto = DateTime.Now.Minute;

            return hj;
        }

        /// <summary>
        /// Método de retorno da diferença entre duas datas, 
        /// devolvendo a quantidade de Dias.
        /// </summary>
        [AcceptVerbs("GET")]
        [Route("DateDiffDays")]
        public double DateDiffDays(DateTime dateInit, DateTime dateEnd)
        {
            double retorno = (dateEnd - dateInit).TotalDays;
            return retorno;
        }



        /// <summary>
        /// Método de retorno da diferença entre duas datas, 
        /// devolvendo a quantidade de Horas.
        /// </summary>
        [AcceptVerbs("GET")]
        [Route("DateDiffHours")]
        public double DateDiffHours(DateTime dateInit, DateTime dateEnd)
        {
            double retorno = (dateEnd - dateInit).TotalHours;
            return retorno;
        }


        /// <summary>
        /// Método de retorno da diferença entre duas datas, 
        /// devolvendo a quantidade de minutos.
        /// </summary>
        [AcceptVerbs("GET")]
        [Route("DateDiffMinutes")]
        public double DateDiffMinutes(DateTime dateInit, DateTime dateEnd)
        {
            double retorno = (dateEnd - dateInit).TotalMinutes;
            return retorno;
        }



    }
}
