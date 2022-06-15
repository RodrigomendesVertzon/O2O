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

namespace API_SDM_TESTES
{

    [RoutePrefix("api/Ticket")]
    public class TicketController : ApiController
    {

        [AcceptVerbs("GET")]
        [Route("getHoje")]
        public Hoje getHoje( )
        {
            Hoje hj = new Hoje();

            hj.Dia = DateTime.Now.Day;
            hj.Mes = DateTime.Now.Month;
            hj.Ano = DateTime.Now.Year;
            hj.Hora = DateTime.Now.Hour;
            hj.Minuto = DateTime.Now.Minute;
            hj.DiaSemana = DateTime.Now.DayOfWeek;

            return hj;
        }


        [AcceptVerbs("GET")]
        [Route("ConsultarTickets")]
        public List<Ticket> ConsultarUsuarios(String login)
        {
            GetTicket gt = new GetTicket();
            return gt.GetTicketsByLogin(login);
        }

        [AcceptVerbs("GET")]
        [Route("ValidTicket")]
        public int ValidTicket(String chamado)
        {
            GetTicket gt = new GetTicket();
            return gt.ValidTicket(chamado);
        }


        [AcceptVerbs("GET")]
        [Route("ConsultarTicketsByPhone")]
        public List<Ticket> ConsultarUsuariosByPhone(String phone)
        {
            GetTicket gt = new GetTicket();
            return gt.GetTicketsByPhone(phone);
        }


        [AcceptVerbs("GET")]
        [Route("ConsultarCommentsByNumber")]
        public List<Comments> ConsultarCommentsByNumber(string ticketNumber)
        {
            GetTicket gt = new GetTicket();
            return gt.GetComments(ticketNumber, "LOG");
        }

        [AcceptVerbs("GET")]
        [Route("GetTicketsByRefNum")]
        public Ticket GetTicketsByRefNum(string refNum)
        {
            GetTicket tk = new GetTicket();
            return tk.GetTicketsByRefNum(refNum);
        }

        [AcceptVerbs("GET")]
        [Route("InfoTicketsByLogin")]
        public ListTickets InfoTicketsByLogin(string login)
        {
            GetTicket gt = new GetTicket();
            return gt.InfoTicketsByLogin(login);
        }


        [AcceptVerbs("GET")]
        [Route("InfoTicketsREByLogin")]
        public ListTickets InfoTicketsREByLogin(string login)
        {
            GetTicket gt = new GetTicket();
            return gt.InfoTicketsREByLogin(login);
        }


        [AcceptVerbs("GET")]
        [Route("ConsultarTicketsByRequested")]
        public List<Ticket> ConsultarUsuariosByRequested(String phone)
        {
            GetTicket gt = new GetTicket();
            return gt.GetTicketsByPhone(phone);
        }

        [AcceptVerbs("GET")]
        [Route("ValidationsCpf")]
        public int ValidationsCpf(string cpf, string telefone)
        {
            ValidationsUsers vld = new ValidationsUsers();
            return vld.ValidaCPFIni(telefone,cpf);
        }

        [AcceptVerbs("GET")]
        [Route("ValidationsNomeMae")]
        public int ValidationsNomeMae(string priNomeMae, string telefone)
        {
            ValidationsUsers vld = new ValidationsUsers();
            return vld.ValidaNomeMaeIni(priNomeMae, telefone);
        }

        [AcceptVerbs("GET")]
        [Route("ResertPassAD")]
        public string ResertPassAD(string telefone) 
        {

            ActiveDirectoryItens ADI = new ActiveDirectoryItens();

            return ADI.GeneratePass();


        }

        [AcceptVerbs("POST")]
        [Route("RegisterComment")]
        public string RegisterComment(Comments Comentarios)
        {

            RegisterAndUpdateTickets rt = new RegisterAndUpdateTickets();

            rt.RegisterComment(Comentarios.Phone, Comentarios.Descricao, Comentarios.Numero);

            return "Sucesso!";
        }


        [AcceptVerbs("POST")]
        [Route("ChangeStatusTicketReOpen")]
        public string ChangeStatusTicketReOpen(Comments ComentarioMud)
        {
            RegisterAndUpdateTickets rt = new RegisterAndUpdateTickets();
            rt.ChangeStatus(ComentarioMud.Numero, ComentarioMud.Descricao, ComentarioMud.Phone, "crs:400001");
            return "Sucesso!";
        }


        [AcceptVerbs("POST")]
        [Route("CreateTicket")]
        public Ticket CreateTicket(Ticket Chamado)
        {
            RegisterAndUpdateTickets gt = new RegisterAndUpdateTickets();
            return gt.createTicket(Chamado);
        }

        [AcceptVerbs("POST")]
        [Route("UpdatePassworSDM")]
        public string UpdatePassworSDM(string telefone, string Pass)
        {

            GetTicket gt = new GetTicket();


            return gt.updatePassSDM(telefone, Pass);
        }


        [AcceptVerbs("POST")]
        [Route("CreateGetSelect")]
        public DataTable CreateGetSelect(QueryTable queryTable)
        {
            
            Connections cn = new Connections();
            DataTable dt = new DataTable();
            dt = cn.GetSelects(queryTable);

            return dt;
        }

        [AcceptVerbs("POST")]
        [Route("InsertValuesToTable")]
        public string InsertValuesToTable(InsertTable insertTable)
        {
            
            Connections cn = new Connections();
            DataTable dt = new DataTable();
            return cn.InsertValuesToTable(insertTable);

       
        }

    }
}
