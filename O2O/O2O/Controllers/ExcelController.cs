using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using O2O.Conectores.Excel.Controllers;
using O2O.Conectores.Excel.Models;

namespace O2O.Controllers
{
    [RoutePrefix("api/Excel")]
    public class ExcelController : ApiController
    {


        /// <summary>
        /// Método de inserção é uma tabela qualquer partindo de um JSON
        /// </summary>
        [AcceptVerbs("POST")]
        [Route("getValuesAllCoumns")]
        public DataSet GetPlan(QuerySheet querySheet)
        { ExcelToDataSet excel = new ExcelToDataSet();
            return excel.SheetValues(querySheet);
        }

        [AcceptVerbs("POST")]
        [Route("InsertValues")]
        public DataSet InsertValues(QuerySheet querySheet)
        {
            ExcelToDataSet excel = new ExcelToDataSet();
            return excel.SheetValues(querySheet);
        }


    }
}
