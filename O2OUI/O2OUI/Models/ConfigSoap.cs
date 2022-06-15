using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace O2OUI.Models
{
    public class ConfigSoap
    {

        private string autenticationType;
        private string senha;
        private string usuario;
        private string url;

        public ConfigSoap (){}

        public ConfigSoap(string autenticationType, string senha, string usuario, string url)
        {
            autenticationType = this.autenticationType;
            senha = this.senha;
            usuario = this.usuario;
            url = this.url;

        }

        public string AutenticationType
        {
            get
            {
                return autenticationType;
            }
            set
            {
                autenticationType = value;
            }
        }

        public string Senha
        {
            get
            {
                return senha;
            }
            set
            {
                senha = value;
            }
        }

        public string Usuario
        {
            get
            {
                return usuario;
            }
            set
            {
                usuario = value;
            }
        }

        public string Url
        {
            get
            {
                return url;
            }
            set
            {
                url = value;
            }
        }

    }
}