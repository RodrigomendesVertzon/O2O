using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace O2OUI.Conectores.Excel.Models
{
    public class QuerySheet
    {
        private string identificador;
        private string whereClause;

        public string WhereClause
        {
            get { return whereClause; }
            set { whereClause = value; }
        }


        public string Identificador
        {
            get { return identificador; }
            set { identificador = value; }
        }


    }
}