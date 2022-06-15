using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace O2OUI.Models
{
    public class BancoDeDados
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Conexao { get; set; }
    }
}
