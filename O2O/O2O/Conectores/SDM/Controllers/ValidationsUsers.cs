using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Xml;
using System.Web;

namespace O2O.Conectores.SDM.Controllers
{
    public class ValidationsUsers
    {


        public int newloginSDM()
        {
            int SID;
            string userStr = "ServiceDesk";
            string PassStr = "Vtz1317@#";
            
           
            
            O2O.SDM.USD_WebService sd = new O2O.SDM.USD_WebService();

            SID = sd.login(userStr, PassStr);

            return SID;
        }



        public int ValidaCPFIni(string telefone, string cpf)
        {

            int SID = newloginSDM();
            O2O.SDM.USD_WebService sd = new O2O.SDM.USD_WebService();
            string wc = "z_str_cpf like '" + cpf + "' and phone_number like '" + telefone + "'";
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