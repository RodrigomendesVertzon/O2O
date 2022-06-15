using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace O2OUI.Conectores.SqlServer.Models
{
    public class UpdateTable
    {

        private string tabela;
        private string[] campos;
        private string[] valores;
        private string clausula;
        private string identificadorBanco;


        public UpdateTable(string tabela, string[] campos, string[] valores, string clausula , string identificadorBanco)
        {
            this.tabela = tabela;
            this.campos = campos;
            this.valores = valores;
            this.identificadorBanco = identificadorBanco;
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
        public string[] Campos
        {
            get
            {
                return campos;
            }
            set
            {
                campos = value;
            }
        }
        public string[] Valores
        {
            get
            {
                return valores;
            }
            set
            {
                valores = value;
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


    }
}