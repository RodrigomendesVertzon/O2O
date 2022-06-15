using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Data;
using System.Data.SqlClient;
using O2O.Models;


namespace O2O
{
    public class GetConfigs
    {
        public static string GetXmlConfig()
        {
            
            XmlDocument returnXml = new XmlDocument();
            returnXml.Load("E:/O2OApi/configs.xml");
            return returnXml.InnerXml;
            
        }

        public static  ConfigSoap GetConfigSoap(string identificador) 
        {
            ConfigSoap cs = new ConfigSoap();
            SqlConnection sqlConn = GetConfigs.GetConectionO2O();
            sqlConn.Open();
            string query = "select * from SoapConectors  where Identificador like '" + identificador +"'";

            SqlCommand selctCommand = new SqlCommand(query, sqlConn);
            SqlDataReader dataReader = selctCommand.ExecuteReader();

            DataTable tbEsquema = dataReader.GetSchemaTable();
            DataTable tbRetorno = new DataTable();

            foreach (DataRow r in tbEsquema.Rows)
            {
                if (!tbRetorno.Columns.Contains(r["ColumnName"].ToString()))
                {
                    DataColumn col = new DataColumn()
                    {
                        ColumnName = r["ColumnName"].ToString(),
                        Unique = Convert.ToBoolean(r["IsUnique"]),
                        AllowDBNull = Convert.ToBoolean(r["AllowDBNull"]),
                        ReadOnly = Convert.ToBoolean(r["IsReadOnly"])
                    };
                    tbRetorno.Columns.Add(col);
                }
            }

            while (dataReader.Read())
            {
                DataRow novaLinha = tbRetorno.NewRow();
                for (int i = 0; i < tbRetorno.Columns.Count; i++)
                {
                    novaLinha[i] = dataReader.GetValue(i);
                }
                tbRetorno.Rows.Add(novaLinha);
            }


            string AutenticationType;
            string url;
            string Senha;
            string Usuario;
            cs.AutenticationType = tbRetorno.Rows[0].Field<string>("TipoDeAutenticacao");
            cs.Senha = tbRetorno.Rows[0].Field<string>("Senha");
            cs.Usuario = tbRetorno.Rows[0].Field<string>("Usuario");
            cs.Url = tbRetorno.Rows[0].Field<string>("URL");

            sqlConn.Close();
            return cs;
        }



        public static SqlConnection GetConectionO2O() {


            string server = "";
            string user = "";
            string pass = "";
            string db = "";

            string xml;


            XmlDocument returnXml = new XmlDocument();
            returnXml.LoadXml(GetConfigs.GetXmlConfig());
            XmlNodeList nodeListFields;

            nodeListFields = returnXml.SelectNodes("//banco");
            foreach (XmlNode field in nodeListFields)
            {
                db = field.InnerText;
            }

            nodeListFields = returnXml.SelectNodes("//usuario");
            foreach (XmlNode field in nodeListFields)
            {
                user = field.InnerText;
            }

            nodeListFields = returnXml.SelectNodes("//senha");
            foreach (XmlNode field in nodeListFields)
            {
                pass = field.InnerText;
            }

            nodeListFields = returnXml.SelectNodes("//ip");
            foreach (XmlNode field in nodeListFields)
            {
                server = field.InnerText;
            }

            string connectionString = "Data Source=" + server + ";";
            connectionString += "Initial Catalog=" + db + ";";
            connectionString += "User id=" + user + ";";
            connectionString += "Password=" + pass + ";";
            SqlConnection sqlConn = new SqlConnection(connectionString);

            return sqlConn;
        }



        


    }
}