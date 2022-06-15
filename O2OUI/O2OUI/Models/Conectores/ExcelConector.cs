using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace O2OUI.Models
{
    public class ExcelConector
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Ip { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public string DiretorioCompartilhado { get; set; }
        
        [Required(ErrorMessage = "Campo obrigatório.")]
        public string NomeArquivo { get; set; }
        
        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Sheet { get; set; }

        public string Usuario { get; set; }

        public string Senha { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Identificador { get; set; }
    }
}
