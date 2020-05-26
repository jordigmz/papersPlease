using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using Microsoft.VisualBasic;

namespace PapersPlease
{
    class ListaPasaportes
    {
        List<Pasaporte> pasaportesMujeres;
        List<Pasaporte> pasaportesHombres;
        Juego j;

        public ListaPasaportes()
        {
            j = new Juego();
            pasaportesMujeres = new List<Pasaporte>();
            pasaportesHombres = new List<Pasaporte>();
        }
        public List<Pasaporte> GetPasaportesMujeres()
        {
            return pasaportesMujeres;
        }
        public void SetPasaportesMujeres(List<Pasaporte> pasaportesMujeres)
        {
            this.pasaportesMujeres = pasaportesMujeres;
        }

        public List<Pasaporte> GetPasaportesHombres()
        {
            return pasaportesHombres;
        }
        public void SetPasaportesHombres(List<Pasaporte> pasaportesHombres)
        {
            this.pasaportesHombres = pasaportesHombres;
        }

        public void AddMujer(Pasaporte pasaporte)
        {
            pasaportesMujeres.Add(pasaporte);
        }

        public void AddHombre(Pasaporte pasaporte)
        {
            pasaportesHombres.Add(pasaporte);
        }

        public void Crear()
        {
            try
            {
                do
                {
                    j.SetNombreJugador(Interaction.InputBox("Por favor, inserte un alias.", "Nombre", "", -1, -1));

                } while (j.GetNombreJugador() == "");

                MessageBox.Show("Bienvenid@ " + j.GetNombreJugador() + "!");

                string linea = "", nombreTemp = "", apellidoTemp = "", dniTemp = "", fechaNacimientoTemp = "";
                int cont = 1;

                //mujeres
                StreamReader nombresM = File.OpenText(@"imagenes\assets\text\f\nombres.txt");
                StreamReader apellidosM = File.OpenText(@"imagenes\assets\text\f\apellidos.txt");
                StreamReader dniM = File.OpenText(@"imagenes\assets\text\f\dni.txt");
                StreamReader fechasNacimientoM = File.OpenText(@"imagenes\assets\text\f\fechasNacimiento.txt");

                do
                {
                    linea = nombresM.ReadLine();
                    if (linea != null)
                    {
                        nombreTemp=linea;
                    }

                    linea = apellidosM.ReadLine();
                    if (linea != null)
                    {
                        apellidoTemp = linea;
                    }

                    linea = dniM.ReadLine();
                    if (linea != null)
                    {
                        dniTemp = linea;
                    }

                    linea = fechasNacimientoM.ReadLine();
                    if (linea != null)
                    {
                        fechaNacimientoTemp = linea;
                    }

                    AddMujer(new Pasaporte(
                        Directory.GetCurrentDirectory() + @"\imagenes\assets\personajes\f\p" + cont + ".png",
                        Directory.GetCurrentDirectory() + @"\imagenes\assets\documentacion\f\d" + cont + ".png",
                        Directory.GetCurrentDirectory() + @"\imagenes\assets\documentacion\f\d" + cont + ".png",
                        nombreTemp,
                        apellidoTemp,
                        dniTemp,
                        Convert.ToDateTime(fechaNacimientoTemp)
                    ));

                    cont++;

                } while (linea != null);

                nombresM.Close();
                apellidosM.Close();
                dniM.Close();
                fechasNacimientoM.Close();

                //hombres
                StreamReader nombresH = File.OpenText(@"imagenes\assets\text\m\nombres.txt");
                StreamReader apellidosH = File.OpenText(@"imagenes\assets\text\m\apellidos.txt");
                StreamReader dniH = File.OpenText(@"imagenes\assets\text\m\dni.txt");
                StreamReader fechasNacimientoH = File.OpenText(@"imagenes\assets\text\m\fechasNacimiento.txt");

                do
                {
                    linea = nombresH.ReadLine();
                    if (linea != null)
                    {
                        nombreTemp = linea;
                    }

                    linea = apellidosH.ReadLine();
                    if (linea != null)
                    {
                        apellidoTemp = linea;
                    }

                    linea = dniH.ReadLine();
                    if (linea != null)
                    {
                        dniTemp = linea;
                    }

                    linea = fechasNacimientoH.ReadLine();
                    if (linea != null)
                    {
                        fechaNacimientoTemp = linea;
                    }

                    AddHombre(new Pasaporte(
                        Directory.GetCurrentDirectory() + @"\imagenes\assets\personajes\m\p" + cont + ".png",
                        Directory.GetCurrentDirectory() + @"\imagenes\assets\documentacion\m\d" + cont + ".png",
                        Directory.GetCurrentDirectory() + @"\imagenes\assets\documentacion\m\d" + cont + ".png",
                        nombreTemp,
                        apellidoTemp,
                        dniTemp,
                        Convert.ToDateTime(fechaNacimientoTemp)
                    ));

                    cont++;

                } while (linea != null);

                nombresH.Close();
                apellidosH.Close();
                dniH.Close();
                fechasNacimientoH.Close();
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
                StreamReader fr = File.OpenText(j.GetNombreJugador() + ".txt");



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
                StreamWriter fw = File.CreateText(j.GetNombreJugador() + "_Medias.txt");



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
    }
}
