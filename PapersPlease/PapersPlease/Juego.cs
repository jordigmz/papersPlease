using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapersPlease
{
    class Juego
    {
        DateTime dia; //Convert.ToDateTime(string);
        int acumuladorDias;
        int ahorros;
        List<Pasaporte> personajes;

        public Juego():this(DateTime.Now, 0, 0) {}
        public Juego(DateTime dia, int acumuladorDias, int ahorros)
        {
            personajes = new List<Pasaporte>();

        }

        public DateTime GetDia()
        {
            return dia;
        }
        public void SetDia(DateTime dia)
        {
            this.dia = dia;
        }

        public int GetAcumuladorDias()
        {
            return acumuladorDias;
        }
        public void SetAcumuladorDias(int acumuladorDias)
        {
            this.acumuladorDias = acumuladorDias;
        }

        public int GetAhorros()
        {
            return ahorros;
        }
        public void SetAhorros(int ahorros)
        {
            this.ahorros = ahorros;
        }

        public List<string> GetPersonajesVistos()
        {
            return personajesVistos;
        }
        public void SetPersonajesVistos(List<string> personajesVistos)
        {
            this.personajesVistos = personajesVistos;
        }

    }
}
