using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace O2O.Conectores.SoapToRest.Models
{
    public class CallSoap
    {


        private string xml;
        private string identificador;

        public CallSoap(string xml, string identificador)
        {
            this.xml = xml;
            this.identificador = identificador;
        }

        public string Xml
        {
            get
            {
                return xml;
            }
            set
            {
                xml = value;
            }
        }

        public string Identificador
        {
            get
            {
                return identificador;
            }
            set
            {
                identificador = value;
            }
        }


    }
}