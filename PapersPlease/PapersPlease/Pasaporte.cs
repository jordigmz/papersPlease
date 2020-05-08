using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapersPlease
{
    class Pasaporte
    {
        string nombre;
        string apellidos;
        string dni;
        DateTime fechaNacimiento;

        public Pasaporte():this("", "", "", DateTime.Now) { }
        public Pasaporte(string nombre, string apellidos, string dni, DateTime fechaNacimiento)
        {
            this.nombre = nombre;
            this.apellidos = apellidos;
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

        public string GetApellidos()
        {
            return apellidos;
        }
        public void SetApellidos(string apellidos)
        {
            this.apellidos = apellidos;
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
    }
}
