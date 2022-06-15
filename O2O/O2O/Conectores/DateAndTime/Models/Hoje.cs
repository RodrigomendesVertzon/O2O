using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace O2O.Conectores.DateAndTime.Models
{
    public class Hoje
    {

        private int dia;
        private int mes;
        private int ano;
        private int hora;
        private int minuto;
        private DayOfWeek diaSemana;

        public Hoje()
        {

        }

        public Hoje(int dia, int mes, int ano, int hora, int minuto, DayOfWeek diaSemana)
        {
            this.dia = dia;
            this.mes = mes;
            this.ano = ano;
            this.hora = hora;
            this.minuto = minuto;

        }

        public int Dia
        {
            get
            {
                return dia;
            }
            set
            {
                dia = value;
            }
        }

        public int Mes
        {
            get
            {
                return mes;
            }
            set
            {
                mes = value;
            }
        }

        public int Ano
        {
            get
            {
                return ano;
            }
            set
            {
                ano = value;
            }
        }

        public int Hora
        {
            get
            {
                return hora;
            }
            set
            {
                hora = value;
            }
        }

        public int Minuto
        {
            get
            {
                return minuto;
            }
            set
            {
                minuto = value;
            }
        }

        public DayOfWeek DiaSemana
        {
            get
            {
                return diaSemana;
            }
            set
            {
                diaSemana = value;
            }
        }


    }
}