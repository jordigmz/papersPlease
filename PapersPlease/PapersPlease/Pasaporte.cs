﻿using System;
using System.IO;
using System.Threading.Tasks;

namespace PapersPlease
{
    class Pasaporte : IComparable<Pasaporte>
    {
        string pathImagen; // Nuevo
        string nombre;
        string apellido;
        string dni;
        DateTime fechaNacimiento;

        public Pasaporte():this("", "", "", DateTime.Now) { }
        public Pasaporte(string nombre, string apellido, string dni, DateTime fechaNacimiento)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.dni = dni;
            this.fechaNacimiento = fechaNacimiento;
        }

        public string GetNombre()
        {
            return nombre;
        }
        public void SetNombre(string nombre)
        {
            this.nombre = nombre;
        }

        public string GetApellido()
        {
            return apellido;
        }
        public void SetApellido(string apellido)
        {
            this.apellido = apellido;
        }

        public string GetDni()
        {
            return dni;
        }
        public void SetDni(string dni)
        {
            this.dni = dni;
        }

        public DateTime GetFechaNacimiento()
        {
            return fechaNacimiento;
        }
        public void GetFechaNacimiento(DateTime fechaNacimiento)
        {
            this.fechaNacimiento = fechaNacimiento;
        }

        public int CompareTo(Pasaporte p)
        {
            //if atributos iguales devuelve -1 if p es mayor, this es mayor devuelve 1, si son iguales 0

            return 1;
        }
    }
}
