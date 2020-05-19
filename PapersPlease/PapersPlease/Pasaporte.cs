using System;
using System.Threading.Tasks;

namespace PapersPlease
{
    class Pasaporte
    {
        string nombre;
        string primerApellido;
        string segundoApellido;
        string dni;
        DateTime fechaNacimiento;

        public Pasaporte():this("", "", "", "", DateTime.Now) { }
        public Pasaporte(string nombre, string primerApellido, string segundoApellido, string dni, DateTime fechaNacimiento)
        {
            this.nombre = nombre;
            this.primerApellido = primerApellido;
            this.segundoApellido = segundoApellido;
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

        public string GetPrimerApellido()
        {
            return primerApellido;
        }
        public void SetPrimerApellido(string primerApellido)
        {
            this.primerApellido = primerApellido;
        }

        public string GetSegundoApellido()
        {
            return segundoApellido;
        }
        public void SetSegundoApellido(string segundoApellido)
        {
            this.segundoApellido = segundoApellido;
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
