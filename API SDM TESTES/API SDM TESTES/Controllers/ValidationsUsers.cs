using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Xml;
using System.Web;

namespace API_SDM_TESTES.Controllers
{
    public class ValidationsUsers
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



        public int ValidaCPFIni(string telefone, string cpf)
        {

            int SID = newloginSDM();
            O2O.SDM.USD_WebService sd = new O2O.SDM.USD_WebService();
            string wc = "z_str_cpf like '"  +cpf+ "' and phone_number like '"+telefone+"'";
            int lengthList = 0;
            lengthList = sd.doQuery(SID, "cnt", wc).listLength;

            if (lengthList > 0) { return 1; }
            return 0;


            
        }

        public int ValidaNomeMaeIni(string priNomeMae, string telefone)
        {


            int SID = newloginSDM();
            O2O.SDM.USD_WebService sd = new O2O.SDM.USD_WebService();
            string wc = "z_str_pri_nome_mae like '" + priNomeMae + "' and phone_number like '" + telefone + "'";
            int lengthList = 0;
            lengthList = sd.doQuery(SID, "cnt", wc).listLength;

            if (lengthList > 0) { return 1; }
            return 0;

        }


    }
}