using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Xml;
using API_SDM_TESTES.Models;


namespace API_SDM_TESTES.Controllers
{
    public class GetTicket
    {


        public int newloginSDM()
        {
            int SID;
            string userStr = "ServiceDesk";
            string PassStr = "Vtz1317@#";
            /*
            XmlDocument returnXml = new XmlDocument();
            returnXml.Load("C:/Users/user/source/repos/API SDM TESTES/API SDM TESTES\Configs.xml");
            XmlNodeList nodeListLogin;
            XmlNodeList nodeListPass;
            nodeListLogin = returnXml.SelectNodes("//login");
            nodeListPass = returnXml.SelectNodes("//pass");

            foreach (XmlNode field in nodeListLogin)
            {
                userStr = field.InnerText;
            }

            foreach (XmlNode field in nodeListPass)
            {
                PassStr = field.InnerText;
            }
            */
            O2O.SDM.USD_WebService sd = new O2O.SDM.USD_WebService();

            SID = sd.login(userStr, PassStr);

            return SID;
        }

        public int ValidTicket(string chamado)
        {
            int SID = newloginSDM();
            O2O.SDM.USD_WebService sd = new O2O.SDM.USD_WebService();
            string wc = "ref_num like '"+chamado + "'";
            int lengthList = 0;
            lengthList = sd.doQuery(SID, "cr", wc).listLength;

            if(lengthList > 0) { return 1; }
            return 0;

        }


        public List<String> GetFields()
        {
            List<String> fields = new List<String>();
            XmlDocument returnXml = new XmlDocument();
            returnXml.LoadXml("../App_Data/sdm_Data.xml");
            XmlNodeList nodeListFields;
            nodeListFields = returnXml.SelectNodes("//field");
            foreach(XmlNode field in nodeListFields)
            {
                fields.Add(field.InnerText);
            }

            return fields;
        }

        public List<Ticket> GetTicketsByLogin(String login)
        {

            List<Ticket> listaTickets = new List<Ticket>();
            O2O.SDM.USD_WebService sd = new O2O.SDM.USD_WebService();
            int loginSID;
            loginSID = newloginSDM();

            String wc;

            if (login != null && login != "")
            {
                wc = "customer.userid like '" + login + "' " ;
                wc += "and active = 1";
            }

            else
            {
                wc = "active = 1";
            }

            

            int handleList;
            int lengthList;
            String RetornoChamado;
            List<String> numeroChamados = new List<String>();

            String[] atributos = { "ref_num", "status.sym", "description", "persistent_id", "customer.userid" };


            handleList = sd.doQuery(loginSID, "cr", wc).listHandle;
          
            lengthList = sd.doQuery(loginSID, "cr", wc).listLength;

            XmlDocument returnXml = new XmlDocument();
            XmlNodeList nodeListRefNum;
            XmlNodeList nodeListStatus;
            XmlNodeList nodeListPersid;
            XmlNodeList nodeListDescription;
            XmlNodeList nodeListLoginRequested;

            for (int i = 0; i < lengthList; i++)
            {
                Ticket tk = new Ticket();
                


                RetornoChamado = sd.getListValues(loginSID, handleList, i, i, atributos);

                returnXml.LoadXml(RetornoChamado);
                XmlNodeList xmlNodeList = returnXml.SelectNodes("//AttrName[text()='ref_num']/../AttrValue/text()");
                nodeListRefNum = xmlNodeList;
                foreach (XmlNode chamados in nodeListRefNum)
                {
                    numeroChamados.Add(chamados.InnerText);


                    tk.Numero = chamados.InnerText;

                }

                nodeListStatus = returnXml.SelectNodes("//AttrName[text()='status.sym']/../AttrValue/text()");
                foreach (XmlNode chamados in nodeListStatus)
                {
                    numeroChamados.Add(chamados.InnerText);


                    tk.Descricao = chamados.InnerText;

                }

                nodeListDescription = returnXml.SelectNodes("//AttrName[text()='description']/../AttrValue/text()");
                foreach (XmlNode chamados in nodeListStatus)
                {
                    numeroChamados.Add(chamados.InnerText);


                    tk.Descricao = chamados.InnerText;

                }

                nodeListPersid = returnXml.SelectNodes("//AttrName[text()='persistent_id']/../AttrValue/text()");
                foreach (XmlNode chamados in nodeListStatus)
                {
                    numeroChamados.Add(chamados.InnerText);

                    tk.Descricao = chamados.InnerText;

                }

                nodeListLoginRequested = returnXml.SelectNodes("//AttrName[text()='customer.userid']/../AttrValue/text()");
                foreach (XmlNode chamados in nodeListStatus)
                {
                    numeroChamados.Add(chamados.InnerText);


                    tk.LoginRequested = chamados.InnerText;

                }



                listaTickets.Add(tk);



            }






            return listaTickets;


        }

      


        public ListTickets InfoTicketsByLogin(string login)
        {

            ListTickets retorno = new ListTickets();

            List<Ticket> Lista = new List<Ticket>();
            Lista = GetTicketsByLogin(login);
            String info="";
            int tamanho = Lista.Count;

            foreach (Ticket tk in Lista)
            {
                info += tk.Numero + ", ";

            }


            info = info.Substring(0, info.Length -2);
            retorno.InfoTicket = info;
            return retorno;

        }


        public List<Comments> GetComments(string refnum, string tipo)
        {
            List<Comments> commentsForRefnum = new List<Comments>();
            int handleList;
            int loginSID;
            string wc;
            int lengthList;
            if(tipo == "ST")
                wc = "call_req_id.ref_num = '" + refnum + "' and (type = 'ST' or type = 'RO')";
            else
            wc = "call_req_id.ref_num = '"+refnum+"' and type = '"+tipo+"'";
            List<String> returnComments = new List<String>();




            O2O.SDM.USD_WebService sd = new O2O.SDM.USD_WebService();
            loginSID = newloginSDM();


            String[] atributos = { "call_req_id.ref_num", "analyst.last_name", "description", "persistent_id" };


            handleList = sd.doQuery(loginSID, "alg", wc).listHandle;
            lengthList = sd.doQuery(loginSID, "alg", wc).listLength;
            int cont = 0;


            for (int i = lengthList; i > cont; i--)
            {

                returnComments.Add(sd.getListValues(loginSID, handleList, i-1, i-1, atributos));
                XmlDocument returnXml = new XmlDocument();
                XmlNodeList nodeListRefNum;
                XmlNodeList nodeListDescription;
                XmlNodeList nodeListAnalist;


                foreach (String Chamado in returnComments)
                {
                    Comments cm = new Comments();

                    returnXml.LoadXml(Chamado);
                    nodeListRefNum = returnXml.SelectNodes("//AttrName[text()='call_req_id.ref_num']/../AttrValue/text()");
                    nodeListDescription = returnXml.SelectNodes("//AttrName[text()='description']/../AttrValue/text()");
                    nodeListAnalist = returnXml.SelectNodes("//AttrName[text()='analyst.last_name']/../AttrValue/text()");
                    foreach (XmlNode chamados in nodeListRefNum)
                    {
                         
                        cm.Numero= chamados.InnerText;

                    }
                    foreach (XmlNode chamados in nodeListDescription)
                    {

                        cm.Descricao = chamados.InnerText;

                    }
                    foreach (XmlNode chamados in nodeListAnalist)
                    {

                        cm.CommentLastName = chamados.InnerText;

                    }

                    commentsForRefnum.Add(cm);
                }
                
             }


                return commentsForRefnum;
        }

        public List<Ticket> GetTicketsByPhone(String phone)
        {

            List<Ticket> listaTickets = new List<Ticket>();


            O2O.SDM.USD_WebService sd = new O2O.SDM.USD_WebService();
            int loginSID;
            loginSID = newloginSDM();

            String wc;

            if (phone != null && phone != "")
            {
                wc = "customer.phone_number like '" + phone + "' ";


            }

            else
            {
                wc = "active = 1";
            }

            int handleList;
            int lengthList;
            List<String> RetornoChamado = new List<String>();
            List<String> numeroChamados = new List<string>();
            Ticket tk = new Ticket();

            String[] atributos = { "ref_num", "status.sym", "description", "persistent_id", "customer.userid" };


            handleList = sd.doQuery(loginSID, "cr", wc).listHandle;
            lengthList = sd.doQuery(loginSID, "cr", wc).listLength;
            for (int i = 0; i < lengthList; i++)
            {

                RetornoChamado.Add(sd.getListValues(loginSID, handleList, i, i, atributos));

                XmlDocument returnXml = new XmlDocument();
                XmlNodeList nodeListRefNum;
                XmlNodeList nodeListStatus;
                XmlNodeList nodeListPersid;
                XmlNodeList nodeListDescription;
                XmlNodeList nodeListLoginRequested;

                foreach (String Chamado in RetornoChamado)
                {
                    returnXml.LoadXml(Chamado);
                    nodeListRefNum = returnXml.SelectNodes("//AttrName[text()='ref_num']/../AttrValue/text()");
                    foreach (XmlNode chamados in nodeListRefNum)
                    {
                        numeroChamados.Add(chamados.InnerText);

                        tk.Codigo = loginSID;
                        tk.Numero = chamados.InnerText;

                    }


                    nodeListStatus = returnXml.SelectNodes("//AttrName[text()='status.sym']/../AttrValue/text()");
                    foreach (XmlNode chamados in nodeListStatus)
                    {
                        numeroChamados.Add(chamados.InnerText);

                        tk.Codigo = loginSID;
                        tk.Descricao = chamados.InnerText;

                    }

                    nodeListDescription = returnXml.SelectNodes("//AttrName[text()='description']/../AttrValue/text()");
                    foreach (XmlNode chamados in nodeListStatus)
                    {
                        numeroChamados.Add(chamados.InnerText);

                        tk.Codigo = loginSID;
                        tk.Descricao = chamados.InnerText;

                    }


                    nodeListPersid = returnXml.SelectNodes("//AttrName[text()='persistent_id']/../AttrValue/text()");
                    foreach (XmlNode chamados in nodeListStatus)
                    {
                        numeroChamados.Add(chamados.InnerText);

                        tk.Codigo = loginSID;
                        tk.Descricao = chamados.InnerText;

                    }

                    nodeListLoginRequested = returnXml.SelectNodes("//AttrName[text()='customer.userid']/../AttrValue/text()");
                    foreach (XmlNode chamados in nodeListStatus)
                    {
                        numeroChamados.Add(chamados.InnerText);


                        tk.LoginRequested = chamados.InnerText;

                    }


                    listaTickets.Add(tk);

                }


            }

            return listaTickets;


        }



        public Ticket GetTicketsByRefNum(String refnum)
        {

            List<Ticket> listaTickets = new List<Ticket>();
            O2O.SDM.USD_WebService sd = new O2O.SDM.USD_WebService();
            int loginSID;
            loginSID = newloginSDM();
            List<Comments> comentarios = new List<Comments>();
            List<Comments> alterStatusComments = new List<Comments>();

            String wc;
            wc = "ref_num like '" + refnum + "' ";

            String RetornoChamado;
            List<String> numeroChamados = new List<String>();

            String[] atributos = { "ref_num", "status.sym", "description", "persistent_id", "customer.userid" };

            XmlDocument returnXml = new XmlDocument();
            XmlNodeList nodeListRefNum;
            XmlNodeList nodeListStatus;
            XmlNodeList nodeListPersid;
            XmlNodeList nodeListDescription;
            XmlNodeList nodeListLoginRequested;

            Ticket tk = new Ticket();
            RetornoChamado = sd.doSelect(loginSID, "cr", wc, 1, atributos);

                returnXml.LoadXml(RetornoChamado);
                XmlNodeList xmlNodeList = returnXml.SelectNodes("//AttrName[text()='ref_num']/../AttrValue/text()");
                nodeListRefNum = xmlNodeList;
                foreach (XmlNode chamados in nodeListRefNum)
                {
                    numeroChamados.Add(chamados.InnerText);
                    tk.Numero = chamados.InnerText;

                }

                nodeListStatus = returnXml.SelectNodes("//AttrName[text()='status.sym']/../AttrValue/text()");
                foreach (XmlNode chamados in nodeListStatus)
                {
                    numeroChamados.Add(chamados.InnerText);
                    tk.Status = chamados.InnerText;

                }

                nodeListDescription = returnXml.SelectNodes("//AttrName[text()='description']/../AttrValue/text()");
                foreach (XmlNode chamados in nodeListDescription)
                {
                    numeroChamados.Add(chamados.InnerText);
                    tk.Descricao = chamados.InnerText;

                }

                nodeListPersid = returnXml.SelectNodes("//AttrName[text()='persistent_id']/../AttrValue/text()");
                foreach (XmlNode chamados in nodeListPersid)
                {
                    numeroChamados.Add(chamados.InnerText);
                    tk.Persid = chamados.InnerText;

                }

                nodeListLoginRequested = returnXml.SelectNodes("//AttrName[text()='customer.userid']/../AttrValue/text()");
                foreach (XmlNode chamados in nodeListLoginRequested)
                {
                    numeroChamados.Add(chamados.InnerText);
                    tk.LoginRequested = chamados.InnerText;

                }

            comentarios = GetComments(refnum, "LOG");
            alterStatusComments = GetComments(refnum, "ST");
            tk.AlterStatus = alterStatusComments;
            tk.Commentarios = comentarios;

            return tk;

        }

        public string updatePassSDM(string telefone, string password)
        {

            int SID = 0;
            GetTicket gt = new GetTicket();
            SID = gt.newloginSDM();

            String[] atributos = { "persistent_id", "userid" };
            String[] attrvalls = { "contact_num", password };
            XmlDocument returnXml = new XmlDocument();
            O2O.SDM.USD_WebService sd = new O2O.SDM.USD_WebService();
            string wc = "phone_number like '" + telefone + "'";

            String RetornoXmlCnt;
            
            string persid = "";

            

            RetornoXmlCnt = sd.doSelect(SID, "cnt", wc, 1, atributos);

            returnXml.LoadXml(RetornoXmlCnt);
            XmlNodeList xmlNodeList = returnXml.SelectNodes("//AttrName[text()='persistent_id']/../AttrValue/text()");

            foreach (XmlNode chamados in xmlNodeList)
            {
                persid = chamados.InnerText;
            }

            try
            {
                sd.updateObject(SID, persid, attrvalls, atributos);
                return "Senha Resetada com sucesso.";
            }
            catch (Exception e) { return "Não foi possivel fazer o reset" + e;  }
            
        }


        

        public ListTickets InfoTicketsREByLogin(string login)
        {

            ListTickets retorno = new ListTickets();

            List<Ticket> Lista = new List<Ticket>();
            Lista = GetTicketsREByLogin(login);
            String info="";
            int tamanho = Lista.Count;

            foreach (Ticket tk in Lista)
            {
                info += tk.Numero + ", ";

            }

            info = info.Substring(0, info.Length -2);
            retorno.InfoTicket = info;
            return retorno;

        }

        public List<Ticket> GetTicketsREByLogin(String login)
        {

            List<Ticket> listaTickets = new List<Ticket>();
            O2O.SDM.USD_WebService sd = new O2O.SDM.USD_WebService();
            int loginSID;
            loginSID = newloginSDM();

            String wc;

                wc = "customer.userid like '" + login + "' ";
                wc += "and status.resolved = 1";
            
            int handleList;
            int lengthList;
            String RetornoChamado;
            List<String> numeroChamados = new List<String>();

            String[] atributos = { "ref_num", "status.sym", "description", "persistent_id", "customer.userid" };

            handleList = sd.doQuery(loginSID, "cr", wc).listHandle;
            lengthList = sd.doQuery(loginSID, "cr", wc).listLength;

            XmlDocument returnXml = new XmlDocument();
            XmlNodeList nodeListRefNum;
            XmlNodeList nodeListStatus;
            XmlNodeList nodeListPersid;
            XmlNodeList nodeListDescription;
            XmlNodeList nodeListLoginRequested;

            for (int i = 0; i < lengthList; i++)
            {
                Ticket tk = new Ticket();

                RetornoChamado = sd.getListValues(loginSID, handleList, i, i, atributos);

                returnXml.LoadXml(RetornoChamado);
                XmlNodeList xmlNodeList = returnXml.SelectNodes("//AttrName[text()='ref_num']/../AttrValue/text()");
                nodeListRefNum = xmlNodeList;
                foreach (XmlNode chamados in nodeListRefNum)
                {
                    numeroChamados.Add(chamados.InnerText);
                    tk.Numero = chamados.InnerText;
                }

                nodeListStatus = returnXml.SelectNodes("//AttrName[text()='status.sym']/../AttrValue/text()");
                foreach (XmlNode chamados in nodeListStatus)
                {
                    numeroChamados.Add(chamados.InnerText);
                    tk.Descricao = chamados.InnerText;
                }

                nodeListDescription = returnXml.SelectNodes("//AttrName[text()='description']/../AttrValue/text()");
                foreach (XmlNode chamados in nodeListStatus)
                {
                    numeroChamados.Add(chamados.InnerText);
                    tk.Descricao = chamados.InnerText;
                }

                nodeListPersid = returnXml.SelectNodes("//AttrName[text()='persistent_id']/../AttrValue/text()");
                foreach (XmlNode chamados in nodeListStatus)
                {
                    numeroChamados.Add(chamados.InnerText);
                    tk.Descricao = chamados.InnerText;
                }

                nodeListLoginRequested = returnXml.SelectNodes("//AttrName[text()='customer.userid']/../AttrValue/text()");
                foreach (XmlNode chamados in nodeListStatus)
                {
                    numeroChamados.Add(chamados.InnerText);
                    tk.LoginRequested = chamados.InnerText;
                }

                listaTickets.Add(tk);

            }

            return listaTickets;

        }




    }
}
