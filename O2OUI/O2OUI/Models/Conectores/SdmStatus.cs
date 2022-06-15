using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace O2OUI.Models
{
    public enum StatusTypes
    {
        Aberto = 1,
        Reaberto = 2,
        Resolvido = 3,
        Fechado = 4
    }
    public class SdmStatus
    {
        public int Id { get; set; }

        public int IdSdm { get; set; }
        public SdmConector SdmConector { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Status { get; set; }

        public StatusTypes StatusType { get; set; }

        public ICollection<SdmConector> SdmConectors { get; set; }

    }
}
