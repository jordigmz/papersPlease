using System;
using System.IO;
using System.Threading.Tasks;

namespace PapersPlease
{
    class Pasaporte : IComparable<Pasaporte>
    {
        string personajeImagen;
        string pasaporteImagen;
        string visadoImagen;
        string nombre;
        string apellido;
        string dni;
        DateTime fechaNacimiento;

        public Pasaporte():this("", "", "", "", "", "", DateTime.Now) { }
        public Pasaporte(string personajeImagen, string pasaporteImagen, string visadoImagen, string nombre, string apellido, string dni, DateTime fechaNacimiento)
        {
            this.personajeImagen = personajeImagen;
            this.pasaporteImagen = pasaporteImagen;
            this.visadoImagen = visadoImagen;
            this.nombre = nombre;
            this.apellido = apellido;
            this.dni = dni;
            this.fechaNacimiento = fechaNacimiento;
        }

        public string GetPersonajeImagen()
        {
            return personajeImagen;
        }
        public void SetPersonajeImagen(string personajeImagen)
        {
            this.personajeImagen = personajeImagen;
        }

        public string GetPasaporteImagen()
        {
            return pasaporteImagen;
        }
        public void SetPasaporteImagen(string pasaporteImagen)
        {
            this.pasaporteImagen = pasaporteImagen;
        }

        public string GetVisadoImagen()
        {
            return visadoImagen;
        }
        public void SetVisadoImagen(string visadoImagen)
        {
            this.visadoImagen = visadoImagen;
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
            if (p.GetPersonajeImagen().CompareTo(this.GetPersonajeImagen()) == 0 &&
                p.GetPasaporteImagen().CompareTo(this.GetPasaporteImagen()) == 0 &&
                p.GetVisadoImagen().CompareTo(this.GetVisadoImagen()) == 0 &&
                p.GetNombre().CompareTo(this.GetNombre()) == 0 &&
                p.GetApellido().CompareTo(this.GetApellido()) == 0 &&
                p.GetDni().CompareTo(this.GetDni()) == 0 &&
                p.GetFechaNacimiento().CompareTo(this.GetFechaNacimiento()) == 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
    }
}
