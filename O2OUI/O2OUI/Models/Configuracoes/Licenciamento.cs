using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace O2OUI.Models
{
    public enum LicenciamentoDados
    {
        SQL = 1,
        SDM = 2,
        Oracle = 3,
        MySql = 4,
        Excel = 5,
        MSActivedDirectory = 6,
        ServiceNow = 7,
        SoapRequest = 8
    }
    public class Licenciamento
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public LicenciamentoDados LicenciamentoDado { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public string ChaveLicença { get; set; }
    }
}
