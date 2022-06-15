using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace O2OUI.Models
{
    public class SNowConector
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Nome { get; set; }

        [Url]
        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Url { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Identificador { get; set; }

    }
}

