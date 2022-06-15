using DocumentFormat.OpenXml.Drawing.Diagrams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Web;

namespace O2O.Conectores.SqlServer.Models
{
    [Description("Coluna de queries.")]
    public class QueryTable
    {
        

        private int tamanho;
        private string tabela;
        private string clausula;        
        private string identificadorBanco;
        private string[] colunas;

        public QueryTable() { }

        public QueryTable(int tamanho, string tabela, string usuario, string senha, string clausula, string ip, string identificadorBanco, string[] colunas)
        {
            this.tamanho = tamanho;
            this.tabela = tabela;
            this.clausula = clausula;
            this.identificadorBanco = identificadorBanco;
            this.colunas = colunas;
            
        }

        public int Tamanho
        {
            get
            {
                return tamanho;
            }
            set
            {
                tamanho = value;
            }
        }


        public string Tabela
        {
            get
            {
                return tabela;
            }
            set
            {
                tabela = value;
            }
        }

        public string Clausula
        {
            get
            {
                return clausula;
            }
            set
            {
                clausula = value;
            }
        }

        public string IdentificadorBanco
        {
            get
            {
                return identificadorBanco;
            }
            set
            {
                identificadorBanco = value;
            }
        }
        public string[] Colunas
        {
            get
            {
                return colunas;
            }
            set
            {
                colunas = value;
            }
        }


    }
}