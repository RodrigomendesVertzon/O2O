using System;
using System.Text;
using System.Linq;
using System.DirectoryServices;
using System.Web;
using System.Xml;
using System.DirectoryServices.AccountManagement;

namespace API_SDM_TESTES.Controllers
{
    public class ActiveDirectoryItens
    {




        public int ResertPass(string telefone)
        {

            int SID=0;
            GetTicket gt = new GetTicket();
            SID = gt.newloginSDM();

            String[] atributos = { "last_name", "first_name"};
            XmlDocument returnXml = new XmlDocument();
            O2O.SDM.USD_WebService sd = new O2O.SDM.USD_WebService();
            string wc = "phone_number like '" + telefone + "'";

            String RetornoXmlCnt;
            
            string nome="";

            string userDn;

            RetornoXmlCnt = sd.doSelect(SID, "cnt", wc, 1, atributos);

            returnXml.LoadXml(RetornoXmlCnt);
            XmlNodeList xmlNodeList = returnXml.SelectNodes("//AttrName[text()='first_name']/../AttrValue/text()");

            foreach (XmlNode chamados in xmlNodeList)
            {
                nome = chamados.InnerText;
            }

            XmlNodeList xmlNodeListSN = returnXml.SelectNodes("//AttrName[text()='last_name']/../AttrValue/text()");

            foreach (XmlNode chamados in xmlNodeListSN)
            {
                nome += " "+chamados.InnerText;
            }

            userDn = "CN=" + nome + ",CN=Users,DC=vertzon,DC=com,DC=br";

            newPassword("rodrigo.mendes", "testes");

            return 0;





        }


        private bool Authenticate(string userName,
            string password, string domain)
        {
            bool authentic = false;
            try
            {
                DirectoryEntry entry = new DirectoryEntry("LDAP://" + domain,
                    userName, password);
                object nativeObject = entry.NativeObject;
                authentic = true;
            }
            catch (DirectoryServicesCOMException) { }
            return authentic;
        }



        public string newPassword(string username, string newPassword)
        {

            String domain = "DC=vertzon,DC=com,DC=br";
            String user = "Administrator";
            String Pass = "Vertzon@2018";


            using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, "VERTZON", domain, ContextOptions.SimpleBind, user, Pass))
            {
                using (UserPrincipal userPrincipal = UserPrincipal.FindByIdentity(pc, username))
                {
                    userPrincipal.SetPassword(newPassword);

                    return "Vazio";
                }
            }
        }

        public String GeneratePass()
        {

            int TamanhoDaSenha = 14;
            StringBuilder strbld = new StringBuilder(100);

            string validar = "abcdefghijklmnozABCDEFGHIJKLMNOZ1234567890@#$&!";
                try
                {
                    
                    Random random = new Random();
                    while (0 < TamanhoDaSenha--)
                    {
                        strbld.Append(validar[random.Next(validar.Length)]);
                    }
                    
                }
                catch (Exception)
                {
                    
                }

            return strbld.ToString();

        }




    }
}