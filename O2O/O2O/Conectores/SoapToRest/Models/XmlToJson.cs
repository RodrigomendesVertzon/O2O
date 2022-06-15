using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace O2O.Conectores.SoapToRest.Models
{
    public class XmlToJson
    {


        private string json;
        private string identificador;

        public XmlToJson(string json, string identificador)
        {
            this.json = json;
            this.identificador = identificador;
        }

        public string Json 
        { 
            get
            {
                return json;
            }
            set
            {
                json = value;
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