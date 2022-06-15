using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using O2O.Conectores.SDM.Models;
using O2O.Conectores.SDM.Controllers;


namespace O2O.Controllers
{
    [RoutePrefix("api/SDM")]
    public class SDMController : ApiController
    {

        /// <summary>
        /// Método de retorno da lista do objeto ticket, 
        /// onde os tickets estiverem abertos baseado no login do usuário final afetado.
        /// </summary>
        [AcceptVerbs("GET")]
        [Route("ConsultarTickets")]
        public List<Ticket> ConsultarUsuarios(String login)
        {
            GetTicket gt = new GetTicket();
            return gt.GetTicketsByLogin(login);
        }

        /// <summary>
        /// Método de para validação se o chamado existe baseado no número.
        /// </summary>
        [AcceptVerbs("GET")]
        [Route("ValidTicket")]
        public int ValidTicket(String chamado)
        {
            GetTicket gt = new GetTicket();
            return gt.ValidTicket(chamado);
        }

        /// <summary>
        /// Método de retorno da lista do objeto tickets abertos baseado no telefone do usuário final afetado.
        /// </summary>
        [AcceptVerbs("GET")]
        [Route("ConsultarTicketsByPhone")]
        public List<Ticket> ConsultarUsuariosByPhone(String phone)
        {
            GetTicket gt = new GetTicket();
            return gt.GetTicketsByPhone(phone);
        }

        /// <summary>
        /// Método de retorno da lista do objeto comentário do chamado baseado no número do chamado.
        /// </summary>
        [AcceptVerbs("GET")]
        [Route("ConsultarCommentsByNumber")]
        public List<Comments> ConsultarCommentsByNumber(string ticketNumber)
        {
            GetTicket gt = new GetTicket();
            return gt.GetComments(ticketNumber, "LOG");
        }

        /// <summary>
        /// Método de retorno do objeto ticket baseado no comentário.
        /// </summary>
        [AcceptVerbs("GET")]
        [Route("GetTicketsByRefNum")]
        public Ticket GetTicketsByRefNum(string refNum)
        {
            GetTicket tk = new GetTicket();
            return tk.GetTicketsByRefNum(refNum);
        }

        /// <summary>
        /// Método de retorno da string da lista de tickets abertos para aquele login.
        /// </summary>
        [AcceptVerbs("GET")]
        [Route("InfoTicketsByLogin")]
        public ListTickets InfoTicketsByLogin(string login)
        {
            GetTicket gt = new GetTicket();
            return gt.InfoTicketsByLogin(login);
        }


        /// <summary>
        /// Método de retorno da string da lista de tickets resolvidos para aquele login.
        /// </summary>
        [AcceptVerbs("GET")]
        [Route("InfoTicketsREByLogin")]
        public ListTickets InfoTicketsREByLogin(string login)
        {
            GetTicket gt = new GetTicket();
            return gt.InfoTicketsREByLogin(login);
        }

        /// <summary>
        /// Método de retorno da lista de tickets abertos para aquele telefone.
        /// </summary>
        [AcceptVerbs("GET")]
        [Route("ConsultarTicketsByRequested")]
        public List<Ticket> ConsultarUsuariosByRequested(String phone)
        {
            GetTicket gt = new GetTicket();
            return gt.GetTicketsByPhone(phone);
        }


        /// <summary>
        /// Método de retorno boleano informando se o telefone e o CPF são validos na base.
        /// </summary>
        [AcceptVerbs("GET")]
        [Route("ValidationsCpf")]
        public int ValidationsCpf(string cpf, string telefone)
        {
            ValidationsUsers vld = new ValidationsUsers();
            return vld.ValidaCPFIni(telefone, cpf);
        }

        /// <summary>
        /// Método de retorno boleano informando se o nome da Mãe e o CPF são validos na base.
        /// </summary>
        [AcceptVerbs("GET")]
        [Route("ValidationsNomeMae")]
        public int ValidationsNomeMae(string priNomeMae, string telefone)
        {
            ValidationsUsers vld = new ValidationsUsers();
            return vld.ValidaNomeMaeIni(priNomeMae, telefone);
        }

        /// <summary>
        /// Método de registro de comentário através de um objeto comentário.
        /// </summary>
        [AcceptVerbs("POST")]
        [Route("RegisterComment")]
        public string RegisterComment(Comments Comentarios)
        {

            RegisterAndUpdateTickets rt = new RegisterAndUpdateTickets();

            rt.RegisterComment(Comentarios.Phone, Comentarios.Descricao, Comentarios.Numero);

            return "Sucesso!";
        }

        /// <summary>
        /// Método de reabertura de chamados 
        /// recebendo o objeto commentário para reabertura.
        /// </summary>
        [AcceptVerbs("POST")]
        [Route("ChangeStatusTicketReOpen")]
        public string ChangeStatusTicketReOpen(Comments ComentarioMud)
        {
            RegisterAndUpdateTickets rt = new RegisterAndUpdateTickets();
            rt.ChangeStatus(ComentarioMud.Numero, ComentarioMud.Descricao, ComentarioMud.Phone, "crs:400001");
            return "Sucesso!";
        }

        /// <summary>
        /// Método de abertura de chamados 
        /// </summary>
        [AcceptVerbs("POST")]
        [Route("CreateTicket")]
        public Ticket CreateTicket(Ticket Chamado)
        {
            RegisterAndUpdateTickets gt = new RegisterAndUpdateTickets();
            return gt.createTicket(Chamado);
        }

        /// <summary>
        /// Método de Atualização de senha interna do CA SDM.
        /// </summary>
        [AcceptVerbs("POST")]
        [Route("UpdatePassworSDM")]
        public string UpdatePassworSDM(string telefone, string Pass)
        {

            GetTicket gt = new GetTicket();


            return gt.updatePassSDM(telefone, Pass);
        }



    }
}
