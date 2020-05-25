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
        string nombreJugador;
        int contadorDias;
        int ahorros;
        DateTime dia; //Convert.ToDateTime(string);
        List<Pasaporte> personajes;

        public Juego():this("", 0, 0, DateTime.Now) { }
        public Juego(string nombreJugador, int contadorDias, int ahorros, DateTime dia)
        {
            this.nombreJugador = nombreJugador;
            this.contadorDias = contadorDias;
            this.ahorros = ahorros;
            this.dia = dia;

            personajes = new List<Pasaporte>();
        }

        public string GetNombreJugador()
        {
            return nombreJugador;
        }
        public void SetNombreJugador(string nombreJugador)
        {
            this.nombreJugador = nombreJugador;
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
            return contadorDias;
        }
        public void SetAcumuladorDias(int acumuladorDias)
        {
            this.contadorDias = acumuladorDias;
        }

        public int GetAhorros()
        {
            return ahorros;
        }
        public void SetAhorros(int ahorros)
        {
            this.ahorros = ahorros;
        }

        public List<Pasaporte> GetPersonajes()
        {
            return personajes;
        }
        public void SetPersonajes(List<Pasaporte> personajes)
        {
            this.personajes = personajes;
        }

    }
}
