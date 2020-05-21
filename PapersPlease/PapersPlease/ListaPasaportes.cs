using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace PapersPlease
{
    class ListaPasaportes
    {
        List<Pasaporte> pasaportes;

        public ListaPasaportes()
        {
            pasaportes = new List<Pasaporte>();
        }
        
        public List<Pasaporte> GetListaPasaportes()
        {
            return pasaportes;
        }
        public void SetListaPasaportes(List<Pasaporte> pasaportes)
        {
            this.pasaportes = pasaportes;
        }

        public void Add(Pasaporte p)
        {
            pasaportes.Add(p);
        }

        public void Crear()
        {
            try
            {
                StreamWriter fw = File.CreateText("partida.txt"); // preguntar partida a usuario

                //cargo nuevos

                fw.Close();
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("No se ha encontrado el fichero.");
            }
            catch (PathTooLongException)
            {
                MessageBox.Show("El nombre del fichero es demasiado largo.");
            }
            catch (IOException)
            {
                MessageBox.Show("Error en el fichero.");
            }
        }

        public void Cargar()
        {
            try
            {
                StreamReader fr = File.OpenText("partidaMitad.txt"); // preguntar partida a usuario



                fr.Close();
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("No se ha encontrado el fichero.");
            }
            catch (PathTooLongException)
            {
                MessageBox.Show("El nombre del fichero es demasiado largo.");
            }
            catch (IOException)
            {
                MessageBox.Show("Error en el fichero.");
            }
        }

        public void Guardar()
        {
            try
            {
                StreamReader fr = File.OpenText("partida.txt");



                fr.Close();
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("No se ha encontrado el fichero.");
            }
            catch (PathTooLongException)
            {
                MessageBox.Show("El nombre del fichero es demasiado largo.");
            }
            catch (IOException)
            {
                MessageBox.Show("Error en el fichero.");
            }
        }
    }
}
