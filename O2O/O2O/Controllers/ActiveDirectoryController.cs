using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace O2O.Controllers
{
    [RoutePrefix("api/ActiveDirectory")]
    public class ActiveDirectoryController : ApiController
    {
        /// <summary>
        /// Método de Atualização de senha interna do CA SDM.
        /// </summary>
        [AcceptVerbs("POST")]
        [Route("UpdatePasswordUser")]
        public string UpdatePassworSDM(string User)
        {

            return "";
        }


        /// <summary>
        /// Método de de adição de usuário a um grupo no Microsoft Active Directory
        /// </summary>
        [AcceptVerbs("POST")]
        [Route("AddUserToGroup")]
        public string AddUserToGroup(string user, string group)
        {
            return "";
        }



        /// <summary>
        /// Método de de adição de remoção de usuário a um grupo no Microsoft Active Directory
        /// </summary>
        [AcceptVerbs("POST")]
        [Route("RemoveUserToGroup")]
        public string RemoveUserToGroup(string user, string Group)
        {
            return "";
        }


        /// <summary>
        /// Método de Criação de usuário no Microsoft Active Directory.
        /// </summary>
        [AcceptVerbs("POST")]
        [Route("CreateUser")]
        public string CreateUser(string user, string Nome)
        {

            return "";
        }

    }
}
