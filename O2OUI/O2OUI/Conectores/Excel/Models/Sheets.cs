using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace O2OUI.Conectores.Excel.Models
{
    public class Sheets
    {

        private string sheetName;
        private string pathString;
        private string ip;
        private string fileName;
        private string identificador;

        public string Identificador
        {
            get { return identificador; }
            set { identificador = value; }
        }


        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }


        public string Ip
        {
            get { return ip; }
            set { ip = value; }
        }


        public string PathString
        {
            get { return pathString; }
            set { pathString = value; }
        }


        public string SheetName
        {
            get { return sheetName; }
            set { sheetName = value; }
        }


    }
}