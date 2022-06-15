using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using API_SDM_TESTES.Models;



namespace API_SDM_TESTES.Controllers
{
    public class RegisterAndUpdateTickets
    {

        public int newloginSDM()
        {
            int SID;
            string userStr = "ServiceDesk";
            string PassStr = "Vtz1317@#";
            /*
            XmlDocument returnXml = new XmlDocument();
            returnXml.Load("C:/Users/user/source/repos/API SDM TESTES/API SDM TESTES/Configs.xml");
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



        public bool RegisterComment(string phone, string descriptionUser, string refNum)
        {

            int SID = newloginSDM();
            O2O.SDM.USD_WebService sd = new O2O.SDM.USD_WebService();
            string doSerlectTkt;
            string doSerlectCnt;
            string[] atributos = { "persistent_id", "id" };
            string wcUser = "phone_number like '" + phone + "'";
            string wc = "ref_num like '"+refNum+"'";
            string persidCR = "";
            string id_analyst = "";

            


            doSerlectTkt = sd.doSelect(SID, "cr", wc, 1, atributos);
            doSerlectCnt = sd.doSelect(SID, "cnt", wcUser, 1, atributos);

            XmlDocument returnXml = new XmlDocument();
            returnXml.LoadXml(doSerlectTkt);
            XmlNodeList nodeListPersidCr;
            nodeListPersidCr = returnXml.SelectNodes("//AttrName[text()='persistent_id']/../AttrValue/text()");


            XmlDocument returnXmlCnt = new XmlDocument();
            returnXmlCnt.LoadXml(doSerlectCnt);
            XmlNodeList nodeListPersidCnt;
            nodeListPersidCnt = returnXmlCnt.SelectNodes("//AttrName[text()='id']/../AttrValue/text()");


            foreach (XmlNode chamados in nodeListPersidCr)
            {
                persidCR = chamados.InnerText;
            }

            foreach (XmlNode chamados in nodeListPersidCnt)
            {
                id_analyst = chamados.InnerText;
            }

            string[] attrValls = { "analyst", id_analyst, "description", descriptionUser, "type", "LOG",  "call_req_id", persidCR};
            string out1="", out2="";
            
            try
            {
                sd.createObject(SID, "alg",attrValls, atributos, ref out1, ref out2);
                return true;
            }
            catch {

                return false;
            }

 
            

        }

        public string ChangeStatus(string ref_num, string descriptionCR, string phoneNumber, string status)
        {

            int SID = newloginSDM();
            O2O.SDM.USD_WebService sd = new O2O.SDM.USD_WebService();
            string persidCNT = "";
            string persidCR = "";
            string wc = "ref_num like '" + ref_num + "'";
            string wcCNT = "phone_number like '" + phoneNumber + "'";
            string[] atributos = { "persistent_id" };

            string RetornoChamado = sd.doSelect(SID, "cr", wc, 1, atributos);
            string RetornoCNT = sd.doSelect(SID, "cnt", wcCNT, 1, atributos);
            XmlDocument returnXmlCR = new XmlDocument();
            XmlDocument returnXmlCNT = new XmlDocument();

            returnXmlCR.LoadXml(RetornoChamado);
            returnXmlCNT.LoadXml(RetornoCNT);

            XmlNodeList xmlNodeListCR = returnXmlCR.SelectNodes("//AttrName[text()='persistent_id']/../AttrValue/text()");
            XmlNodeList xmlNodeListCNT = returnXmlCNT.SelectNodes("//AttrName[text()='persistent_id']/../AttrValue/text()");

            foreach (XmlNode chamados in xmlNodeListCR)
            {
                persidCR = chamados.InnerText;

            }

            foreach (XmlNode contato in xmlNodeListCNT)
            {
                persidCNT = contato.InnerText;

            }

            sd.changeStatus(SID, persidCNT, persidCR, descriptionCR, status);

            return "";
        }


        public Ticket createTicket(Ticket novoTkt)
        {
            int SID = 0;
            GetTicket gt = new GetTicket();
            SID = gt.newloginSDM();

            String[] atributos = { "persistent_id", "userid", "id" };
            String[] attrvalls = { "ref_num" };
            XmlDocument returnXml = new XmlDocument();
            O2O.SDM.USD_WebService sd = new O2O.SDM.USD_WebService();
            string wc = "phone_number like '" + novoTkt.PhoneNumberOfRequested + "'";

            String RetornoXmlCnt;

            string persidCnt = "";



            RetornoXmlCnt = sd.doSelect(SID, "cnt", wc, 1, atributos);
            returnXml.LoadXml(RetornoXmlCnt);
            XmlNodeList xmlNodeList = returnXml.SelectNodes("//AttrName[text()='persistent_id']/../AttrValue/text()");

            foreach (XmlNode chamados in xmlNodeList)
            {
                persidCnt = chamados.InnerText;
            }

            XmlNodeList xmlNodeListIDCnt = returnXml.SelectNodes("//AttrName[text()='id']/../AttrValue/text()");
            string idCnt = "";

            foreach (XmlNode chamados in xmlNodeListIDCnt)
            {
                idCnt = chamados.InnerText;
            }


            string descritpionTkt = novoTkt.Descricao;

            string[] attrvalstkt = { "description", descritpionTkt, "customer", idCnt, "requested_by", idCnt, "category", novoTkt.Category, "status", novoTkt.Status };
            string[] propertiesNull = { };
            string ref1 = "";


            string retornoChamado = sd.createRequest(SID, persidCnt, attrvalstkt, propertiesNull, "", attrvalls, ref ref1, ref ref1);

            novoTkt.Numero = ref1;


            return novoTkt;
        }



    }
}