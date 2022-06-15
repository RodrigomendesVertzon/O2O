using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace O2OUI.Models
{
    public class ConfigLabel
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }
        public ICollection<Configuration> Configurations { get; set; }

    }
}
