using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_SDM_TESTES.Models
{
    public class Comments
    {

        private string persid;
        private string numero;
        private string descricao;
        private string commentLastName;
        private string phone;
        private DateTime dateComment;


        public Comments()
        {

        }

        public Comments(string numero, string descricao, string persid, string commentLastName, string phone, DateTime dateComment)
        {
            this.numero = numero;
            this.descricao = descricao;
            this.persid = persid;
            this.commentLastName = commentLastName;
            this.phone = phone;
            this.dateComment = dateComment;

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

        public DateTime DateComment
        {
            get
            {
                return dateComment;
            }
            set
            {
                dateComment = value;
            }
        }

        public string Phone
        {
            get
            {
                return phone;
            }
            set
            {
                phone = value;
            }
        }

        public string CommentLastName 
        {
            get
            {
                return commentLastName;
            }
            set
            {
                commentLastName = value;
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

    }
}