using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using O2O.Conectores.SqlServer.Models;
using O2O.Conectores.SqlServer.Controllers;

namespace O2O.Controllers
{
    [RoutePrefix("api/SQL")]
    public class SqlServerController : ApiController
    {

        /// <summary>
        /// Método de retorno de um select para um array de String JSON.
        /// </summary>
        [AcceptVerbs("POST")]
        [Route("CreateGetSelect")]
        public DataTable CreateGetSelect(QueryTable queryTable)
        {

            Connections cn = new Connections();
            DataTable dt = new DataTable();
            dt = cn.GetSelects(queryTable);
            return dt;
        }

        /// <summary>
        /// Método de inserção é uma tabela qualquer partindo de um JSON
        /// </summary>
        [AcceptVerbs("POST")]
        [Route("InsertValuesToTable")]
        public string InsertValuesToTable(InsertTable insertTable)
        {
            Connections cn = new Connections(); 
            DataTable dt = new DataTable();
            return cn.InsertValuesToTable(insertTable);
        }


        /// <summary>
        /// Método de atualização genérica em uma tabela qualquer partindo de um JSON
        /// </summary>
        [AcceptVerbs("POST")]
        [Route("UpdateValuesToTable")]
        public string UpdateValuesToTable(UpdateTable updateTable)
        {
            Connections cn = new Connections();
            return cn.UpdateValuesToTable(updateTable);


        }

        /// <summary>
        /// Método de execução de procedures
        /// </summary>
        [AcceptVerbs("POST")]
        [Route("ExecProcedure")]
        public string ExecProcedure(UpdateTable updateTable)
        {
            Connections cn = new Connections();
            return cn.UpdateValuesToTable(updateTable);


        }


    }
}
