using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_SDM_TESTES.Models
{
    public class QueryTable
    {

        private int tamanho;
        private string tabela;
        private string clausula;
        private string ip;
        private string usuario;
        private string senha;
        private string identificadorBanco;
        private string[] colunas;

        public QueryTable() { }

        public QueryTable(int tamanho, string tabela, string usuario, string senha, string clausula, string ip, string identificadorBanco, string[] colunas)
        {
            this.tamanho = tamanho;
            this.tabela = tabela;
            this.clausula = clausula;
            this.identificadorBanco = identificadorBanco;
            this.colunas = colunas;
            this.ip = ip;
            this.usuario = usuario;
            this.senha = senha;

        }

        public int Tamanho
        {
            get
            {
                return tamanho;
            }
            set
            {
                tamanho = value;
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


        public string Ip
        {
            get
            {
                return ip;
            }
            set
            {
                ip = value;
            }
        }

        public string Tabela
        {
            get
            {
                return tabela;
            }
            set
            {
                tabela = value;
            }
        }

        public string Clausula
        {
            get
            {
                return clausula;
            }
            set
            {
                clausula = value;
            }
        }

        public string IdentificadorBanco
        {
            get
            {
                return identificadorBanco;
            }
            set
            {
                identificadorBanco = value;
            }
        }
        public string[] Colunas
        {
            get
            {
                return colunas;
            }
            set
            {
                colunas = value;
            }
        }


    }
}