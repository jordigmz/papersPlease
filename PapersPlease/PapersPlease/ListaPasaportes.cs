using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Media.Animation;
using Microsoft.VisualBasic;

namespace PapersPlease
{
    class ListaPasaportes
    {
        List<Pasaporte> pasaportes;
        Jugador j;

        public ListaPasaportes()
        {
            j = new Jugador();
            pasaportes = new List<Pasaporte>();
        }

        public List<Pasaporte> GetPasaportes()
        {
            return pasaportes;
        }
        public void SetPasaportes(List<Pasaporte> pasaportes)
        {
            this.pasaportes = pasaportes;
        }

        public void Add(Pasaporte pasaporte)
        {
            pasaportes.Add(pasaporte);
        }


        public void Crear()
        {
            try
            {
                if (j.GetNombreJugador() == "")
                {
                    do
                    {
                        j.SetNombreJugador(Interaction.InputBox("Por favor, inserte un alias.", "Nombre", "", -1, -1));

                    } while (j.GetNombreJugador() == "");

                    MessageBox.Show("Bienvenid@ " + j.GetNombreJugador() + "!");
                }
                
                string linea = "", nombreTemp = "", apellidoTemp = "", dniTemp = "", fechaNacimientoTemp = "";
                int cont = 1;

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

                    if (linea != null)
                    {
                        Add(new Pasaporte(
                            Directory.GetCurrentDirectory() + @"\imagenes\assets\personajes\f\p" + cont + ".png",
                            Directory.GetCurrentDirectory() + @"\imagenes\assets\documentacion\f\d" + cont + ".png",
                            Directory.GetCurrentDirectory() + @"\imagenes\assets\documentacion\f\d" + cont + ".png",
                            nombreTemp,
                            apellidoTemp,
                            dniTemp,
                            Convert.ToDateTime(fechaNacimientoTemp)
                        ));

                        cont++;
                    }

                } while (linea != null);

                nombresM.Close();
                apellidosM.Close();
                dniM.Close();
                fechasNacimientoM.Close();

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

                    if (linea != null)
                    {
                        Add(new Pasaporte(
                        Directory.GetCurrentDirectory() + @"\imagenes\assets\personajes\m\p" + cont + ".png",
                        Directory.GetCurrentDirectory() + @"\imagenes\assets\documentacion\m\d" + cont + ".png",
                        Directory.GetCurrentDirectory() + @"\imagenes\assets\documentacion\m\d" + cont + ".png",
                        nombreTemp,
                        apellidoTemp,
                        dniTemp,
                        Convert.ToDateTime(fechaNacimientoTemp)
                    ));

                        cont++;
                    }
                    
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

        public void Cargar(string partida)
        {
            try
            {
                StreamReader fr = File.OpenText(partida + ".txt");

                string linea = fr.ReadLine();
                if (linea != null)
                {
                    j.SetNombreJugador(linea);
                }

                linea = fr.ReadLine();
                if (linea != null)
                {
                    j.SetContadorDias(Convert.ToInt32(linea));
                }

                linea = fr.ReadLine();
                if (linea != null)
                {
                    j.SetAhorros(Convert.ToInt32(linea));
                }

                linea = fr.ReadLine();
                if (linea != null)
                {
                    j.SetDia(Convert.ToDateTime(linea));
                }

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

        public void Guardar(string partida)
        {
            try
            {
                do
                {
                    partida = Interaction.InputBox("Por favor, registre la partida.", "Nombre", "", -1, -1);

                } while (partida == "");

                StreamWriter fw = File.CreateText(partida + ".txt");

                fw.WriteLine(j.GetNombreJugador());
                fw.WriteLine(j.GetContadorDias());
                fw.WriteLine(j.GetAhorros());
                fw.WriteLine(j.GetDia());

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
