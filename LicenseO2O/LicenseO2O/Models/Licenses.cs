using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LicenseO2O.Models
{
    public class Licenses
    {
        private String server;  
        private String keyValue;
        private DateTime expirationDate;
        private Connector connectors;

        public Connector Connectors
        {
            get { return connectors; }
            set { connectors = value; }
        }


        public DateTime ExpirationDate
        {
            get { return expirationDate; }
            set { expirationDate = value; }
        }


        public String KeyValue
        {
            get { return keyValue; }
            set { keyValue = value; }
        }


        public String Server
        {
            get { return Server; }
            set { Server = value; }
        }


    }
}
