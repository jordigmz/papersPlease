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
        Pasaporte p;
        bool perdido;

        public Jugador():this("", 1, 20) { }
        public Jugador(string nombreJugador, int contadorDias, int ahorros)
        {
            this.nombreJugador = nombreJugador;
            this.contadorDias = contadorDias;
            this.ahorros = ahorros;
            p = new Pasaporte();
            perdido = false;
        }

        public string GetNombreJugador()
        {
            return nombreJugador;
        }
        public void SetNombreJugador(string nombreJugador)
        {
            this.nombreJugador = nombreJugador;
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

        public bool GetPerdido()
        {
            return perdido;
        }
        public void SetPerdido(bool perdido)
        {
            this.perdido = perdido;
        }

        public void Amonestar(int jugadorResultado, Pasaporte pCorrecto, Pasaporte pError)
        {
            if (p.CompararPasaportes(pCorrecto, pError) != jugadorResultado)
            {
                SetAhorros(GetAhorros()-5);
                MessageBox.Show("Nota: Amonestación por mala gestión. (-5$)");
            }
            
            if (GetAhorros() <= 0)
            {
                MessageBox.Show("Lo siento, has perdido!");
                SetPerdido(true);
            }
        }
    }
}
