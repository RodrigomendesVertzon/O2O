using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using O2O.Conectores.Excel.Models;

namespace O2O.Conectores.Excel.Controllers
{
    public class ExcelToDataSet
    {

        static Sheets getInfos(string identificador)
        {
            Sheets valores = new Sheets();
            SqlConnection sqlConn = GetConfigs.GetConectionO2O();


            sqlConn.Open();
            string query = "select DiretorioCompartilhado, Id, Identificador, Ip, Nome, NomeArquivo, Senha, Sheet, Usuario from ExcelConector  where Identificador like '" + identificador + "'";


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


            valores.FileName = tbRetorno.Rows[0].Field<string>("NomeArquivo");
            valores.PathString = tbRetorno.Rows[0].Field<string>("DiretorioCompartilhado");
            valores.SheetName = tbRetorno.Rows[0].Field<string>("Sheet");
            valores.Ip = tbRetorno.Rows[0].Field<string>("Ip");

            sqlConn.Close();
            return valores;

        }



        public DataSet SheetValues(QuerySheet querySheet)
        {
            string identificador = querySheet.Identificador;
            string whereClause = querySheet.WhereClause;
            Sheets valores = getInfos(identificador);
            return Parse(valores.PathString+"\\"+valores.FileName, whereClause, valores);
        }


        static DataSet Parse(string fileName, string whereClause, Sheets valores)
        {
            string connectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + ";Extended Properties=Excel 12.0;");

            DataSet data = new DataSet();

            foreach (var sheetName in GetExcelSheetNames(connectionString))
            {
                using (OleDbConnection con = new OleDbConnection(connectionString))
                {
                    var dataTable = new DataTable();
                    string query = string.Format("SELECT * FROM ["+valores.SheetName+"$] where "+ whereClause+"", sheetName);
                    con.Open();
                    OleDbDataAdapter adapter = new OleDbDataAdapter(query, con);
                    adapter.Fill(dataTable);
                    data.Tables.Add(dataTable);
                }
            }

            return data;
        }

        static string[] GetExcelSheetNames(string connectionString)
        {
            OleDbConnection con = null;
            DataTable dt = null;
            con = new OleDbConnection(connectionString);
            con.Open();
            dt = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

            if (dt == null)
            {
                return null;
            }

            String[] excelSheetNames = new String[dt.Rows.Count];
            int i = 0;

            foreach (DataRow row in dt.Rows)
            {
                excelSheetNames[i] = row["TABLE_NAME"].ToString();
                i++;
            }

            return excelSheetNames;
        }



    }
}