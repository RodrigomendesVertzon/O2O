using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace O2OUI.Models
{
    public class Configuration
    {
        public int Id { get; set; }
        public int IdCL { get; set; }
        public ConfigLabel ConfigLabel { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Valores { get; set; }
        public ICollection<ConfigLabel> ConfigLabels { get; set; }
    }
}
