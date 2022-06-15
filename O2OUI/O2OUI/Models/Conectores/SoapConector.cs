using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace O2OUI.Models
{
    public enum Autenticacao
    {
        Basic = 1,
        Ntlm = 2,
        Kerberos = 3,
        NoAuthentication = 4
    }
    public class SoapConector
    { 
        public int Id { get; set; }

        [Url]
        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Url { get; set; }

        public string Usuario { get; set; }

        public string Senha { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Identificador { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public Autenticacao TipoDeAutenticacao { get; set; }

    }
}