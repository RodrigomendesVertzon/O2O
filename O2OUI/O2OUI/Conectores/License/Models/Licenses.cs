using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace O2OUI.Conectores.License.Models
{
    public class Licenses
    {

        private DateTime expirationDate;
        private string licenseCode;
        private string pathFileLicense;

        public Licenses()
        {

        }
        public Licenses(DateTime expirationDate, string licenseCode, string pathFileLicense)
        {
            this.expirationDate = expirationDate;
            this.licenseCode = licenseCode;
            this.pathFileLicense = pathFileLicense;
        }

        public DateTime ExpirationDate
        {
            get
            {
                return expirationDate;
            }
            set
            {
                expirationDate = value;
            }
        }

        public string LicenseCode
        {
            get
            {
                return licenseCode;
            }
            set
            {
                licenseCode = value;
            }
        }


    }
}