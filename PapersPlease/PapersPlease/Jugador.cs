using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PapersPlease
{
    class Jugador
    {
        string nombreJugador;
        int contadorDias;
        int ahorros;
        DateTime dia;
        Pasaporte p;

        public Jugador():this("", 0, 20, DateTime.Now) { }
        public Jugador(string nombreJugador, int contadorDias, int ahorros, DateTime dia)
        {
            this.nombreJugador = nombreJugador;
            this.contadorDias = contadorDias;
            this.ahorros = ahorros;
            this.dia = dia;
            p = new Pasaporte();
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

        public int GetContadorDias()
        {
            return contadorDias;
        }
        public void SetContadorDias(int contadorDias)
        {
            this.contadorDias = contadorDias;
        }

        public int GetAhorros()
        {
            return ahorros;
        }
        public void SetAhorros(int ahorros)
        {
            this.ahorros = ahorros;
        }

        public void Amonestar(int jugadorResultado, Pasaporte pCorrecto, Pasaporte pError)
        {
            if (p.CompararPasaportes(pCorrecto, pError) != jugadorResultado)
            {
                ahorros -= 5;
                MessageBox.Show("Amonestación por mala gestión. (-5$)");
            }
        }
    }
}
