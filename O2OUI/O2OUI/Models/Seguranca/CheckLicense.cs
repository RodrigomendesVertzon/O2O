using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace O2OUI.Models.Seguranca
{
    public class CheckLicense
    {
        public int Id { get; set; }

        public DateTime DataDeChecagem { get; set; }
    }
}
