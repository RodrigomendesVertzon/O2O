using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Xml;
using O2O.Conectores.SqlServer.Models;
using O2O;

namespace O2O.Conectores.SqlServer.Controllers
{
    public class Connections
    {

        public SqlConnection OpenConnection(string identificador)
        {
            SqlConnection sqlConn = GetConfigs.GetConectionO2O();


            sqlConn.Open();
            string query = "select Ip, NomeDoBanco, Usuario, Senha from SqlConectors  where Identificador like '" + identificador +"'";

           
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


            string dbRetorno;
            string Ip;
            string Senha;
            string Usuario;
            dbRetorno = tbRetorno.Rows[0].Field<string>("NomeDoBanco");
            Senha = tbRetorno.Rows[0].Field<string>("Senha");
            Usuario = tbRetorno.Rows[0].Field<string>("Usuario");
            Ip = tbRetorno.Rows[0].Field<string>("Ip");

            sqlConn.Close();

            string connectionStringIdent = "Data Source=" + Ip + ";";
            connectionStringIdent += "Initial Catalog=" + dbRetorno + ";";
            connectionStringIdent += "User id=" + Usuario + ";";
            connectionStringIdent += "Password=" + Senha + ";";
            SqlConnection sqlConnId = new SqlConnection(connectionStringIdent);

            return sqlConnId;
        }


        public void CloseConnection(SqlConnection connection)
        {
            connection.Close();
        }





        public string UpdateValuesToTable(UpdateTable updateTable)
        {
            string query = "update " + updateTable.Tabela;

            query += "set ";
            for (int i = 0; i < updateTable.Campos.Length; i++)
            {
                query += updateTable.Campos[i];
                query += " = ";
                query += updateTable.Valores[i];
                if (i < updateTable.Campos.Length - 1)
                {
                    query += ",";
                }
            }

            if (updateTable.Clausula != null && updateTable.Clausula != "") { query += " where " + updateTable.Clausula; }

            SqlTransaction transaction;

            // Start a local transaction.

            SqlConnection conn = OpenConnection(updateTable.IdentificadorBanco);
            conn.Open();
            transaction = conn.BeginTransaction("SampleTransaction");


            SqlCommand Command = conn.CreateCommand();
            Command.Transaction = transaction;
            Command.Connection = conn;
            Command.CommandText = query;
            int retorno = Command.ExecuteNonQuery();
            transaction.Commit();

            conn.Close();

            if (retorno > 0)
            {
                return "Sucesso";
            }
            else { return "Sem Sucesso"; }
        }



        public string InsertValuesToTable(InsertTable insertTable)
        {
            string query = "insert " + insertTable.Tabela;

            query += "(";
            for (int i = 0; i < insertTable.Campos.Length; i++)
            {
                query += insertTable.Campos[i];
                if (i < insertTable.Campos.Length - 1)
                {
                    query += ",";
                }
            }

            query += ") values (";

            for (int i = 0; i < insertTable.Valores.Length; i++)
            {
                query += insertTable.Valores[i];
                if (i < insertTable.Valores.Length - 1)
                {
                    query += ",";
                }
            }

            query += ")";


            SqlTransaction transaction;

            // Start a local transaction.

            SqlConnection conn = OpenConnection(insertTable.IdentificadorBanco);
            conn.Open();
            transaction = conn.BeginTransaction("SampleTransaction");


            SqlCommand Command = conn.CreateCommand();
            Command.Transaction = transaction;
            Command.Connection = conn;
            Command.CommandText = query;
            int retorno = Command.ExecuteNonQuery();
            transaction.Commit();

            conn.Close();

            if (retorno > 0)
            {
                return "Sucesso";
            }
            else { return "Sem Sucesso"; }
        }

        public DataTable GetSelects(QueryTable queryTable)
        {

            string query = "select ";

            if (queryTable.Tamanho > 0)
            {
                query += " top " + queryTable.Tamanho;
            }


            for (int i = 0; i < queryTable.Colunas.Length; i++)
            {
                query += queryTable.Colunas[i];
                if (i < queryTable.Colunas.Length - 1)
                {
                    query += ",";
                }
            }

            query += " from " + queryTable.Tabela;

            if (queryTable.Clausula != null && queryTable.Clausula != "") { query += " where " + queryTable.Clausula; }


            SqlConnection conn = OpenConnection(queryTable.IdentificadorBanco);
            conn.Open();
            SqlCommand selctCommand = new SqlCommand(query, conn);
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


            conn.Close();

            return tbRetorno;


        }



        private static List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }

        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }


    }
}