using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml;
using API_SDM_TESTES.Controllers;
using API_SDM_TESTES.DAO;
using API_SDM_TESTES.Models;

namespace API_SDM_TESTES.Controllers
{

    [RoutePrefix("api/SQL")]
    public class DatabaseSQL : ApiController
    {

        [AcceptVerbs("POST")]
        [Route("CreateGetSelect")]
        public DataTable CreateGetSelect(QueryTable queryTable)
        {
            Connections cn = new Connections();
            DataTable dt = new DataTable();
            dt = cn.GetSelects(queryTable);

            return dt;
        }


        
    }
}