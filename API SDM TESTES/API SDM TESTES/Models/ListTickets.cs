using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_SDM_TESTES.Models
{
    public class ListTickets
    {
        private string infoTicket;

        public ListTickets() { }

        public ListTickets(string infoTicket) 
        {

            this.infoTicket = infoTicket;
        }

        public string InfoTicket
        {
            get
            {
                return infoTicket;
            }
            set
            {
                infoTicket = value;
            }
        }


    }
}