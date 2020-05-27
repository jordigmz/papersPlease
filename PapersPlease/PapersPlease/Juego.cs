﻿using System;
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
        DateTime dia;

        public Juego():this("", 0, 0, DateTime.Now) { }
        public Juego(string nombreJugador, int contadorDias, int ahorros, DateTime dia)
        {
            this.nombreJugador = nombreJugador;
            this.contadorDias = contadorDias;
            this.ahorros = ahorros;
            this.dia = dia;
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
    }
}
