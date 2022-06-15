using O2OUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace O2OUI.Models
{
    public class SdmViewModel
    {
        public SdmConector SdmConector { get; set; }
        public IEnumerable<SdmStatus> SdmStatus { get; set; }
    }
}
