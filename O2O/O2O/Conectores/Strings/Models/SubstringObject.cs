using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace O2O.Conectores.Strings.Models
{
    public class SubstringObject
    {

        private String valueReplace;
        private String textOld;
        private String valueNew;

        public String ValueNew
        {
            get { return valueNew; }
            set { valueNew = value; }
        }


        public String TextOld
        {
            get { return textOld; }
            set { textOld = value; }
        }


        public String ValueReplace
        {
            get { return valueReplace; }
            set { valueReplace = value; }
        }


    }
}