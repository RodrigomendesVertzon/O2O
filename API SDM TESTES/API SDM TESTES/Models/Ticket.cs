using API_SDM_TESTES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_SDM_TESTES
{
    public class Ticket
    {

        private int codigo;
        private string status;
        private string persid;
        private string numero;
        private string phoneNumberOfRequested;
        private string descricao;
        private string loginRequested;
        private string telefoneRequested;
        private List<Comments> commentarios;
        private List<Comments> alterStatus;
        private DateTime openDate;
        private string category;

        public Ticket() 
        { 
        }

        public Ticket(int codigo, string numero, string descricao, string loginRequested, string telefoneRequested, string status, string phoneNumberOfRequested, string persid, List<Comments> commentarios, List<Comments> alterStatus, DateTime openDate, string category)
        {
            this.codigo = codigo;
            this.numero = numero;
            this.descricao = descricao;
            this.loginRequested = loginRequested;
            this.telefoneRequested = telefoneRequested;
            this.status = status;
            this.phoneNumberOfRequested = phoneNumberOfRequested;
            this.persid = persid;
            this.commentarios = commentarios;
            this.alterStatus = alterStatus;
            this.openDate = openDate;
            this.category = category;
        }

       public string PhoneNumberOfRequested
        {
            get
            {
                return phoneNumberOfRequested;
            }
            set  
            {
                phoneNumberOfRequested = value;
            }
        }

        public string Category
        {
            get
            {
                return category;
            }
            set
            {
                category = value;
            }
        }

        public List<Comments> Commentarios 
        {
            get
            {
                return commentarios;
            }
            set
            {
                commentarios = value;
            }
        }

        public List<Comments> AlterStatus
        {
            get
            {
                return alterStatus;
            }
            set
            {
                alterStatus = value;
            }
        }


        public string Status {

            get
            {
                return status;
            }
            set
            {
                status = value;
            }
        
        }

        public int Codigo
        {
            get
            {
                return codigo;
            }
            set
            {
                codigo = value;
            }

        }

        public string Persid
        {
            get
            {
                return persid;
            }
            set
            {
                persid = value;
            }
        }


        public string Numero
        {
            get
            {
                return numero;
            }
            set
            {
                numero = value;
            }
        }


        public string Descricao
        {
            get
            {
                return descricao;
            }
            set
            {
                descricao = value;
            }

        }

        public string LoginRequested
        {


            get
            {
                return loginRequested;
            }
            set
            {
                loginRequested = value;
            }
        }

        public string TelefoneRequested
        {
            get
            {
                return telefoneRequested;
            }
            set
            {
                telefoneRequested = value;
            }
        }
    }
}